using SecurityModel.Common.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SecurityModel.Common;

public static class AuditJson
{
	public static JsonSerializerOptions CreateDefaultOptions()
	{
		var options = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			WriteIndented = true
		};
		options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
		return options;
	}

	public static AuditData<T> Deserialize<T>(string json, JsonSerializerOptions options = null)
	{
		options ??= CreateDefaultOptions();
		var result = JsonSerializer.Deserialize<AuditData<T>>(json, options);
		if (result is null)
			throw new JsonException("Failed to deserialize AuditData<T>.");
		return result;
	}

	/// <summary>
	/// Deserialize JSON with embedded type information back to AuditData&lt;T&gt;. Handles null
	/// $dataType gracefully by returning an AuditData with null Detail.
	/// </summary>
	public static object DeserializeAuditDynamic(string json, JsonSerializerOptions options = null)
	{
		options ??= CreateDefaultOptions();

		using var doc = JsonDocument.Parse(json);
		var root = doc.RootElement;

		if (!root.TryGetProperty("$dataType", out var typeElem))
		{
			var temp = JsonSerializer.Deserialize<AuditData<object>>(json);
			if (temp.Detail != null && temp.Detail.Data is JsonElement je)
			{
				temp.Detail.Data = ToDynamic(je);
			}
			return temp;
		}

		// Handle null $dataType (when original Detail.Data was null)
		if (typeElem.ValueKind == JsonValueKind.Null)
		{
			// Reconstruct JSON without $dataType and deserialize as object
			using var stream = new System.IO.MemoryStream();
			using var writer = new Utf8JsonWriter(stream);

			writer.WriteStartObject();
			foreach (var prop in root.EnumerateObject())
			{
				if (prop.Name != "$dataType")
				{
					writer.WritePropertyName(prop.Name);
					prop.Value.WriteTo(writer);
				}
			}
			writer.WriteEndObject();
			writer.Flush();

			var reconstructedJson = System.Text.Encoding.UTF8.GetString(stream.ToArray());
			var auditType = typeof(AuditData<>).MakeGenericType(typeof(object));
			return JsonSerializer.Deserialize(reconstructedJson, auditType, options);
		}

		var typeName = typeElem.GetString();
		if (typeName.IsNullOrBlank())
		{
			throw new JsonException("$dataType was null or empty.");
		}

		var dataType = Type.GetType(typeName, throwOnError: false);
		if (dataType is null)
		{
			throw new JsonException($"Could not resolve type '{typeName}'.");
		}

		var auditTypeWithGeneric = typeof(AuditData<>).MakeGenericType(dataType);
		return JsonSerializer.Deserialize(json, auditTypeWithGeneric, options);
	}

	/// <summary>
	/// Convenience method to serialize and deserialize with the nested structure.
	/// </summary>
	public static string Serialize<T>(AuditData<T> audit, JsonSerializerOptions options = null)
	{
		options ??= CreateDefaultOptions();
		return JsonSerializer.Serialize(audit, options);
	}

	/// <summary>
	/// Serialize AuditData&lt;T&gt; with embedded type information for T. Handles null Detail and
	/// Data gracefully.
	/// </summary>
	public static string SerializeWithTypeInfo<T>(AuditData<T> audit, JsonSerializerOptions options = null)
	{
		options ??= CreateDefaultOptions();
		var json = JsonSerializer.Serialize(audit, options);

		// Inject dataType at the root level
		using var doc = JsonDocument.Parse(json);
		var root = doc.RootElement;

		using var stream = new System.IO.MemoryStream();
		using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = options.WriteIndented });

		writer.WriteStartObject();

		// Write $dataType based on whether Detail.Data is null
		if (root.TryGetProperty("detail", out var detailElem) && detailElem.ValueKind == JsonValueKind.Object)
		{
			if (detailElem.TryGetProperty("data", out var dataElem) && dataElem.ValueKind == JsonValueKind.Null)
			{
				writer.WriteNull("$dataType");
			}
			else
			{
				writer.WriteString("$dataType", typeof(T).AssemblyQualifiedName);
			}
		}
		else if (root.TryGetProperty("detail", out _) && detailElem.ValueKind == JsonValueKind.Null)
		{
			writer.WriteNull("$dataType");
		}
		else
		{
			writer.WriteString("$dataType", typeof(T).AssemblyQualifiedName);
		}

		foreach (var prop in root.EnumerateObject())
		{
			writer.WritePropertyName(prop.Name);
			prop.Value.WriteTo(writer);
		}

		writer.WriteEndObject();
		writer.Flush();

		return System.Text.Encoding.UTF8.GetString(stream.ToArray());
	}

	public static object ToDynamic(JsonElement element)
	{
		switch (element.ValueKind)
		{
			case JsonValueKind.Object:
				var obj = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
				foreach (var prop in element.EnumerateObject())
				{
					obj[prop.Name] = ToDynamic(prop.Value);
				}
				return obj;

			case JsonValueKind.Array:
				var list = new List<object>();
				foreach (var item in element.EnumerateArray())
				{
					list.Add(ToDynamic(item));
				}
				return list;

			case JsonValueKind.String:
				// Try to parse as DateTime if possible
				if (element.TryGetDateTime(out DateTime date))
					return date;
				return element.GetString();

			case JsonValueKind.Number:
				// Try integer first, then double
				if (element.TryGetInt64(out long l))
					return l;
				return element.GetDouble();

			case JsonValueKind.True:
				return true;

			case JsonValueKind.False:
				return false;

			case JsonValueKind.Null:
				return null;

			default:
				return null;
		}
	}
}
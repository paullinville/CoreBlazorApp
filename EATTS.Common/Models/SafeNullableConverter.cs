using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EATTS.Common.Models;

public class SafeNullableConverter<T> : JsonConverter<T?>
{
	public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		try
		{
			return JsonSerializer.Deserialize<T>(ref reader, options);
		}
		catch
		{
			// If conversion fails, return null
			reader.Skip();
			return default;
		}
	}

	public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, value, options);
	}
}
using Midland.Core.Validation.Exceptions;

namespace Midland.Core.Common;

public class Detail
{
	private const string ExceptionCommonProperties = "Message Data HelpLink HResult InnerException Source StackTrace TargetSite";

	public Detail()
	{ }

	public Detail(Exception ex)
	{
		if (ex == null) return;
		var exData = new Dictionary<string, string>();
		foreach (var key in ex.Data.Keys)
		{
			exData.TryAdd(key.ToString(), ex.Data[key]?.ToString());
		}
		ExceptionType = ex.GetType().FullName;
		ExceptionMessage = ex.Message;
		Source = ex.Source;
		ExceptionData = exData;
		if (ex is FriendlyValidationException fe)
		{
			foreach (var er in fe.Errors.Values())
			{
				var key = $"{er.Type}-{er.Name}";
				if (exData.ContainsKey(key))
				{
					exData[key] += Environment.NewLine + er.Value;
				}
				else
				{
					ExceptionData.Add(key, er.Value);
				}
			}
		}
		Target = ex.TargetSite?.ToString();
		try
		{
			ex.GetType()
			  .BindablePropertyInfo()
			  .Where(p => !ExceptionCommonProperties.Contains(p.Name))
			  .ForEach(p =>
			  {
				  if (ExceptionProperties.ContainsKey(p.Name))
				  {
					  ExceptionProperties.TryAdd($"{p.DeclaringType.Name}.{p.Name}", ex.GetPropValueSafe(p.Name, declaringTypeFilter: p.DeclaringType)?.ToString());
				  }
				  else
				  {
					  ExceptionProperties.Add(p.Name, ex.GetPropValueSafe(p.Name, declaringTypeFilter: p.DeclaringType)?.ToString());
				  }
			  }

			  );
		}
		catch (Exception ex2)
		{
			exData.TryAdd("Error setting Exception Properties", ex2.Message);
		}
	}

	public Dictionary<string, string> ExceptionData { get; set; }
	public string ExceptionMessage { get; set; }
	public Dictionary<string, string> ExceptionProperties { get; set; } = new Dictionary<string, string>();
	public string ExceptionType { get; set; }
	public string Source { get; set; }

	public string Target { get; set; }

	public override bool Equals(object obj)
	{
		if (obj is Detail details)
		{
			return obj.ToString() == this.ToString();
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ToString().GetHashCode();
	}

	public override string ToString()
	{
		return $"{Source}{EC.Source_Separator}{ExceptionType}";
	}
}
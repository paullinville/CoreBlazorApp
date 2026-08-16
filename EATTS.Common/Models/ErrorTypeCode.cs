namespace EATTS.Common.Models;

public class ErrorTypeCode
{
	public ErrorTypeCode()
	{
	}

	public ErrorTypeCode(IErrorType code)
	{
		ErrorTypeRef = code.ErrorTypeRef;
		Name = code.Description;
	}

	public int ErrorTypeRef { get; set; }
	public string Name { get; set; }
}
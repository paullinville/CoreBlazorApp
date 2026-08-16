using System.Net;
using System.Runtime.Serialization;

namespace Midland.Core.Validation.Exceptions;

[Serializable]
public class FriendlyValidationException : Exception
{
	public FriendlyValidationException(List<ErrorResultError> errors)
	{
		Errors = errors ?? new List<ErrorResultError>();
	}

	public FriendlyValidationException(List<ErrorResultError> errors, string description) : base(description)
	{
		Errors = errors ?? new List<ErrorResultError>();
	}

	public FriendlyValidationException(string title, string description) : base(description)
	{
		Errors = new List<ErrorResultError>();
		Title = title;
	}

	protected FriendlyValidationException(
		SerializationInfo info,
		StreamingContext context) : base(info, context)
	{
	}

	public IReadOnlyCollection<ErrorResultError> Errors { get; private set; }
	public bool RecordInEatts { get; set; }
	public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;
	public string Title { get; set; }

	public void AddError(ErrorResultError errorResultError)
	{
		var lst = Errors.ToList();
		lst.Add(errorResultError);
		Errors = lst;
	}
}
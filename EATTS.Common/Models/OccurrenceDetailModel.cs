using Midland.Core.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EATTS.Common.Models;

public class OccurrenceDetailModel
{
	public OccurrenceDetailModel()
	{ }

	public OccurrenceDetailModel(IEntryOccurrence values)
	{
		if (values == null) return;
		EntryOccurrenceRef = values.EntryOccurrenceRef;
		CallerId = values.CallerId + "";
		Date = values.Date;
		Description = values.Description + "";
		EmailsSent = values.EmailsSent + "";
		Origin = values.Origin + "";
		if (values.ErrorResponse.IsNotNullOrBlank())
		{
			try
			{
				ErrorResponse = System.Text.Json.JsonSerializer.Deserialize<ErrorResponse>(values.ErrorResponse + "");
			}
			catch (Exception ex)
			{
				ErrorResponse = new ErrorResponse();
				ErrorResponse.Messages = ErrorResponse.Messages ?? [];
				ErrorResponse.Messages.Add($"Error getting error response from occurrence table.{ex.Message}");
				ErrorResponse.Messages.Add(values.ErrorResponse);
			}
		}
	}

	public string CallerId { get; set; }
	public DateTime Date { get; set; }
	public string Description { get; set; }
	public string EmailsSent { get; set; }
	public int EntryOccurrenceRef { get; set; }
	public ErrorResponse ErrorResponse { get; set; }
	public List<EntryNoteDetail> Notes { get; set; }
	public string Origin { get; set; }
	public string RawErrorResponse { get; set; }
	public EmployeeSimple User { get; set; }
}
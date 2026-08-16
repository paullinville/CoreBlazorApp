using Microsoft.AspNetCore.Components;
using Midland.Core.Common;

namespace BlazorApp.Components;

public partial class EntryDetail
{
	public EntryDetail()

	{
		ErrorResponse = new ErrorResponse();
	}

	[Parameter]
	public ErrorResponse ErrorResponse { get; set; }
}
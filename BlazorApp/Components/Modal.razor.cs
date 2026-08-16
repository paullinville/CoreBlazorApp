using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components;

public partial class Modal
{
	[Parameter]
	public string Message { get; set; }

	[Parameter]
	public string Title { get; set; }

	private void CloseModal()
	{
		// Logic to close the modal
	}
}
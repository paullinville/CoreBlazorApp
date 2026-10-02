# Copilot Instructions

## General Guidelines
- Unless explicitly specified otherwise, all pages should apply the 'Dense Layout' instructions from the project copilot instructions, including corresponding CSS.
- Use browser tab titles in the format '{ApplicationName} - {PageName}' as a standard for all pages.
- Align submit/action buttons to the right using a shared form action container (applies to submit buttons, including Search page actions). All buttons that affect a form should be right-aligned, and button order should follow Windows conventions: Cancel (if present) to the left of Submit/OK/Apply actions.

## Project-Specific Rules
- Only change the CoreBlazorApp project in future; do not modify other projects because they are referenced NuGet packages.

## Code Style
- Use code behind (separate .razor.cs files) for Blazor pages in CoreBlazorApp. Inline `@code` blocks are fine for Razor components unless specifically directed otherwise.
- Use `Midland.Core.Common.Extensions.IsNullOrBlank` for null/empty string checks and keep `Midland.Core.Common` available as a global using.
- Whenever looping through any `IEnumerable`, always use `Midland.Core.Common.Extensions.Values()`.
- When adding a grid in this codebase, do not create a new model specifically for the grid.
- Never use try/catch when calling repository methods; repository errors must be handled by the established channel event flow. Do not handle repository-call errors in Razor page code-behind; rely on channel event-based error handling per project instructions.
- Always use Telerik controls if available in the CoreBlazorApp codebase, rather than standard HTML elements or other control libraries. If an appropriate Telerik control is not available, ask the developer for a Telerik control to use. If they cannot provide one, then use a standard HTML element or other control library.
- For TelerikTooltip, use the `<Template>` parameter, not `<TooltipTemplate>`, to define tooltip content.
- For TelerikNumericTextBox in this codebase/version, use the Arrows property to control spinner buttons (not ShowSpinButton).


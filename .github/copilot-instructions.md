# Copilot Instructions

## General Guidelines
- Unless explicitly specified otherwise, all pages should apply the 'Dense Layout' instructions from the project copilot instructions, including corresponding CSS.
- Use browser tab titles in the format '{ApplicationName} - {PageName}' as a standard for all pages.
- Align submit/action buttons to the right using a shared form action container (applies to submit buttons, including Search page actions). All buttons that affect a form should be right-aligned, and button order should follow Windows conventions: Cancel (if present) to the left of Submit/OK/Apply actions.

## Code Style
- Use `Midland.Core.Common.Extensions.IsNullOrBlank` for null/empty string checks and keep `Midland.Core.Common` available as a global using.
- Whenever looping through any `IEnumerable`, always use `Midland.Core.Common.Extensions.Values()`.
- When adding a grid in this codebase, do not create a new model specifically for the grid.


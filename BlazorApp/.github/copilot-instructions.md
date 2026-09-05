# Copilot Instructions

## Project Guidelines
- User is a Senior Software Engineer at a large bank, specializes in backend on Microsoft stack, and maintains both API code and database structures. Tailor assistance with enterprise-grade backend and data-focused guidance.
- User frontend preference: use code-behind files instead of inline code in Blazor components.
- User prefers Telerik UI for Blazor package version 12.3.0 in this workspace.
- In this Blazor app, the medium blue-gray page background should apply only when the dark theme is active, not in light mode.
- This CoreBlazorApp project is intended as base functionality for all other projects — a Visual Studio template will be created from it. Code and config should be kept generic/reusable (avoid hardcoding project-specific values) since it will be templatized.
- Use the provided orange SVG logo as a shared application resource, not a one-off favicon. Branding assets should be stored as common reusable resources for the template/app.
- When asked to replace existing UI assets, apply and verify the actual markup change rather than only describing the intended change.
- Use code-behind files for page logic in this project; keep .razor pages markup-only and move logic to corresponding .razor.cs partial classes.
- Unless explicitly specified otherwise, all pages should apply the 'Dense Layout' instructions from the project copilot instructions, including corresponding CSS.

# Midland Blazor WebAssembly Architecture - Frontend Copilot Instructions (Telerik-Only)

## Purpose
These instructions define the standard frontend architecture for all Midland Blazor WebAssembly applications using Telerik UI exclusively.

Copilot must follow these rules for every project built using this architecture.

This ensures:

- Consistent structure
- Consistent UI patterns
- Consistent API access
- Consistent error handling
- Consistent separation of concerns
- Consistent developer experience

------------------------------------------------------------

# Architecture Overview
All Midland Blazor WebAssembly applications are pure client-side UI shells built using:

- Blazor WebAssembly (latest stable version)
- Telerik UI for Blazor (only UI library)
- Code-behind Blazor components (.razor + .razor.cs)
- Common Models returned by backend APIs
- Base Client Repository for all API communication
- Publish-Subscribe Event Bus for global messaging
- Services wrapping the Base Client Repository

Blazor never communicates with APIs directly.
Blazor never handles authentication or token logic.
Blazor never contains backend logic.

------------------------------------------------------------

# Strict Separation of Concerns

### Blazor Frontend MUST use only:
- Common Models
- Base Client Repository
- Event Bus
- Telerik UI components
- Code-behind components
- Services that wrap the Base Client Repository

### Blazor Frontend MUST NOT use:
- DTOs
- EF entities
- Repositories
- Unit of Work
- Binding models
- Validation classes
- Mapping interfaces
- Direct RestEase calls
- HttpClient configuration
- Token retrieval or refresh logic
- Header injection logic
- Backend business logic

These belong exclusively to backend or infrastructure layers.

------------------------------------------------------------

# Base Client Repository Rules (Critical)

All Midland Blazor WASM applications use a Base Client Repository as the single point of API communication.

Copilot must assume:

- All API calls go through the Base Client Repository
- Repository handles HTTP status codes
- Repository interprets MidlandResult<T>
- Repository interprets MidlandErrorResult
- Repository publishes events to the global event bus
- Repository injects all security and API headers
- Repository manages token lifetime
- Repository handles connectivity, authorization, and server errors

Copilot must never generate:

- RestEase calls
- HttpClientFactory setup
- HttpClient configuration
- Token retrieval logic
- Token refresh logic
- Header injection logic
- Error parsing logic
- API exception handling
- Connectivity logic
- Retry logic

These already exist and must not be recreated.

------------------------------------------------------------

# Publish Subscribe Event Bus Rules

The Base Client Repository publishes events such as:

- ApiUnauthorizedEvent
- ApiForbiddenEvent
- ApiNotFoundEvent
- ApiValidationErrorEvent
- ApiServerErrorEvent
- ApiConnectivityErrorEvent
- ApiSuccessEvent
- MidlandErrorEvent

Blazor components must:

- Subscribe to event channels
- React to events
- Display UI notifications (Telerik)
- Update UI state based on events

Blazor components must NOT:

- Parse MidlandErrorResult
- Parse HTTP status codes
- Handle API exceptions
- Implement try/catch around API calls
- Interpret RestEase exceptions
- Implement token logic
- Implement header logic

All of that is handled in the Base Client Repository.

------------------------------------------------------------

# Copilot Must Generate (Frontend)

Copilot must generate:

- Event subscription logic
- UI reactions to events
- Telerik notifications based on events
- Services that wrap the Base Client Repository
- Code-behind components that call the repository
- Clean async UI flows
- Unified error UI triggered by event bus messages
- Telerik UI components only
- Code-behind Blazor components

Copilot must generate UI-level error handling only, never API-level error handling.

------------------------------------------------------------

# Copilot Must NOT Generate (Frontend)

Copilot must never generate:

- HttpClientFactory setup
- HttpClient configuration
- Token retrieval logic
- Token refresh logic
- Security header injection
- Authorization header injection
- RestEase client registration
- Direct RestEase calls
- Error parsing logic
- API exception handling
- Connectivity logic
- Retry logic
- CascadingAuthenticationState
- AuthenticationStateProvider
- AuthorizeView
- [Authorize] attributes
- Login/logout UI
- Claims-based UI logic
- Any code that duplicates or replaces the Base Client Repository
- Any code that duplicates or replaces the Event Bus
- Any UI-level validation or business-rule handling
  - Blazor page code-behind must never attempt to detect, interpret, or handle validation or business rule errors directly.
  - All validation and business rule errors are surfaced exclusively through the Event Bus by the Base Client Repository using ProcessResponse and CheckForErrors.
  - Blazor components may only react to event bus messages such as ApiValidationEvent, ApiErrorEvent, or ResultsMessageEvent.

------------------------------------------------------------

# UI Rules

- In this Blazor app, the medium blue-gray page background should apply only when the dark theme is active, not in light mode.

## Telerik UI for Blazor (Primary and Only UI Library)

Copilot should prefer Telerik for:

- Grid
- Chart
- TreeList
- Scheduler
- Menu
- Drawer
- Inputs (TextBox, NumericTextBox, DatePicker, etc.)
- Notifications
- Dialogs
- Panels
- Cards
- Layout components

There are no secondary UI libraries.

## DataAnnotations for Editors and Forms
Copilot must ensure that all Blazor/Telerik editors — including:

- Inline grid editors  
- Popup grid editors  
- Form-based editors  
- Standalone forms  

use **Data Annotation attributes** from the Common Models for:

- Client-side validation  
- Display names  
- Hints/tooltips  
- Required field indicators  
- StringLength limits  
- Range limits  
- Regex validation  
- Error messages  

Rules:

- Blazor pages must not implement custom validation logic; they must rely entirely on DataAnnotations applied to Common Models.
- Telerik components must bind to DataAnnotations automatically using `TelerikForm`, `TelerikValidationMessage`, and `DataAnnotationsValidator`.
- Inline and popup grid editors must respect DataAnnotations for:
  - Required fields  
  - Maximum lengths  
  - Numeric ranges  
  - Date ranges  
  - Regex constraints  
- Copilot must generate editors that enforce DataAnnotations **before submitting**, preventing invalid data from reaching the Base Client Repository.
- Copilot must not generate any business-rule validation in Blazor; only DataAnnotations-based UI validation is allowed.

------------------------------------------------------------

# Component Structure Rules

Copilot must always generate Blazor components using code-behind:

PageName.razor  
PageName.razor.cs

The .razor file contains:

- Markup
- Telerik components
- Minimal inline logic (event bindings only)

The .razor.cs file contains:

- Fields
- Methods
- Lifecycle events
- Calls to the Base Client Repository
- Event bus subscriptions
- UI state management
- UI reactions to event bus messages only

------------------------------------------------------------

# Authorization Rules

Midland Blazor WASM applications do not use Blazor's built-in authentication system.

Blazor does not:

- Authenticate users
- Manage tokens
- Refresh tokens
- Use CascadingAuthenticationState
- Use AuthenticationStateProvider
- Use AuthorizeView
- Use [Authorize] attributes
- Perform claims-based UI logic

Blazor receives a pre-authenticated security token from an external component.

All authorization enforcement happens in the API, not in Blazor.

------------------------------------------------------------

# State Management

Copilot should use:

- Local component state
- Cascading parameters for shared UI state
- Services for shared business state
- Event bus messages for global state changes

Copilot must avoid:

- Static/global state
- Storing API responses in singletons

------------------------------------------------------------

# Code Quality Expectations

Copilot should:

- Generate clean, readable code
- Use async/await everywhere
- Avoid magic strings
- Use ILogger<T> for logging
- Follow SOLID principles
- Prefer composition over inheritance
- Avoid static helpers unless pure functions

------------------------------------------------------------

# Copilot Behavior Expectations

Copilot should:

- Provide reasoning before generating code
- Suggest multiple UI/UX options when relevant
- Explain tradeoffs
- Generate step-by-step implementation plans
- Produce code ready for GitHub Copilot to apply
- Maintain enterprise-grade patterns
- Avoid simplistic examples

------------------------------------------------------------

# UI/UX Operator Tool Rules (Merged)

## Dense Layout
- Default all Telerik components to **Size="Small"**.
- Use dense spacing (8–12px vertical rhythm).
- Use compact icons (24–28px).
- Use dense grid row height (28–32px).

## Layout Rules
- Application uses a **top AppBar only**.
- **No left navigation** should be generated.
- Page-level actions belong in the page header.

## Grid Rules (TelerikGrid)
- All grids must support:
  - Column **resizing**
  - Column **filtering**
  - Column **sorting**
  - Paging (20–50 rows)
  - Dense row height
  - **Excel export must be available in ALL grids (editable, reporting, search)**  
    - Export **All Records**  
    - Export **Current Page**  

### Reporting & Search Result Grids
- **Never editable**.
- Must include:
  - Column filtering
  - Column sorting
  - Excel export (All Records + Current Page)
- Toolbar must follow:  
  `Search | Clear | Export (All / Page)`

### Editable Grids
- Use row editing or popup editing.
- Avoid cell-level editing.
- Require explicit Save/Cancel.
- **Editable grids must also include Excel export (All / Page)** for consistency.

## Long Text Columns
- For fields with `StringLength(100)` or longer:
  - Display only the **first 75 characters**.
  - Append a clickable **ellipsis (…)**.
  - Clicking the ellipsis opens a popup showing the full text.

## Forms
- Dense spacing.
- Two-column layout on desktop.
- Labels always visible.
- Inline validation messages under fields.

## Dialogs
- Use compact padding.
- Esc closes non-destructive dialogs.

## Theming
- Use a single Telerik theme.
- Prefer ThemeBuilder for customization.

## Accessibility
- Do not remove focus outlines.
- Tab order must follow visual order.

------------------------------------------------------------

# Summary

Midland Blazor WASM applications are pure client UIs:

- Use Common Models
- Use Base Client Repository for all API calls
- Use Event Bus for all error and status messaging
- Use Telerik UI only
- Use code-behind components
- Follow dense operator UI rules
- Follow all grid, truncation, popup, DataAnnotations, and export rules
- Never touch backend concerns
- Never generate DTOs, EF, UOW, repositories, binding models, or validation classes
- Never generate token logic or HttpClient configuration
- Never generate direct RestEase calls
- Only consume the Base Client Repository and react to event bus messages

Copilot must operate strictly within this frontend boundary.

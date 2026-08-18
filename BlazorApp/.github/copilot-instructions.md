# Copilot Instructions

## Project Guidelines
- User is a Senior Software Engineer at a large bank, specializes in backend on Microsoft stack, and maintains both API code and database structures. Tailor assistance with enterprise-grade backend and data-focused guidance.
- User frontend preference: use code-behind files instead of inline code in Blazor components.
- User prefers Telerik UI for Blazor package version 12.3.0 in this workspace.


# **Midland Blazor WebAssembly Architecture — Frontend Copilot Instructions (Telerik‑Only)**

## **Purpose**
These instructions define the **standard frontend architecture** for all Midland Blazor WebAssembly applications using **Telerik UI exclusively**.

Copilot must follow these rules for *every* project built using this architecture.

This ensures:

- Consistent structure  
- Consistent UI patterns  
- Consistent API access  
- Consistent error handling  
- Consistent separation of concerns  
- Consistent developer experience  

---

# **Architecture Overview**
All Midland Blazor WebAssembly applications are **pure client‑side UI shells** built using:

- **Blazor WebAssembly (latest stable version)**  
- **Telerik UI for Blazor** (only UI library)  
- **Code‑behind Blazor components** (`.razor` + `.razor.cs`)  
- **Common Models** returned by backend APIs  
- **Base Client Repository** for all API communication  
- **Publish‑Subscribe Event Bus** for global messaging  
- **Services wrapping the Base Client Repository**

Blazor **never** communicates with APIs directly.  
Blazor **never** handles authentication or token logic.  
Blazor **never** contains backend logic.

---

# **Strict Separation of Concerns**

### Blazor Frontend **MUST use only:**
- Common Models  
- Base Client Repository  
- Event Bus  
- **Telerik UI components**  
- Code‑behind components  
- Services that wrap the Base Client Repository  

### Blazor Frontend **MUST NOT use:**
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

---

# **Base Client Repository Rules (Critical)**

All Midland Blazor WASM applications use a **Base Client Repository** as the *single point of API communication*.

Copilot must assume:

- All API calls go through the Base Client Repository  
- Repository handles HTTP status codes  
- Repository interprets `MidlandResult<T>`  
- Repository interprets `MidlandErrorResult`  
- Repository publishes events to the global event bus  
- Repository injects all security and API headers  
- Repository manages token lifetime  
- Repository handles connectivity, authorization, and server errors  

Copilot must **never** generate:

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

---

# **Publish‑Subscribe Event Bus Rules**

The Base Client Repository publishes events such as:

- `ApiUnauthorizedEvent`  
- `ApiForbiddenEvent`  
- `ApiNotFoundEvent`  
- `ApiValidationErrorEvent`  
- `ApiServerErrorEvent`  
- `ApiConnectivityErrorEvent`  
- `ApiSuccessEvent`  
- `MidlandErrorEvent`  

Blazor components must:

- Subscribe to event channels  
- React to events  
- Display UI notifications (Telerik)  
- Update UI state based on events  

Blazor components must **not**:

- Parse MidlandErrorResult  
- Parse HTTP status codes  
- Handle API exceptions  
- Implement try/catch around API calls  
- Interpret RestEase exceptions  
- Implement token logic  
- Implement header logic  

All of that is handled in the Base Client Repository.

---

# **Copilot Must Generate (Frontend)**

Copilot must generate:

- Event subscription logic  
- UI reactions to events  
- **Telerik notifications** based on events  
- Services that wrap the Base Client Repository  
- Code‑behind components that call the repository  
- Clean async UI flows  
- Unified error UI triggered by event bus messages  
- **Telerik UI components only**  
- Code‑behind Blazor components  

Copilot must generate **UI‑level error handling only**, never API‑level error handling.

---

# **Copilot Must NOT Generate (Frontend)**

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
- `[Authorize]` attributes  
- Login/logout UI  
- Claims-based UI logic  
- Any code that duplicates or replaces the Base Client Repository  
- Any code that duplicates or replaces the Event Bus  

These already exist and must not be recreated.

---

# **UI Rules**

## **Telerik UI for Blazor (Primary and Only UI Library)**

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

There are **no secondary UI libraries**.

---

# **Component Structure Rules**

Copilot must always generate Blazor components using **code‑behind**:

```
PageName.razor
PageName.razor.cs
```

`.razor` file contains:

- Markup  
- Telerik components  
- Minimal inline logic (event bindings only)

`.razor.cs` file contains:

- Fields  
- Methods  
- Lifecycle events  
- Calls to the Base Client Repository  
- Event bus subscriptions  
- UI state management  

---

# **Authorization Rules**

Midland Blazor WASM applications do **not** use Blazor’s built‑in authentication system.

Blazor does **not**:

- Authenticate users  
- Manage tokens  
- Refresh tokens  
- Use CascadingAuthenticationState  
- Use AuthenticationStateProvider  
- Use AuthorizeView  
- Use `[Authorize]` attributes  
- Perform claims-based UI logic  

Blazor **receives** a pre‑authenticated security token from an external component.

All authorization enforcement happens **in the API**, not in Blazor.

---

# **State Management**

Copilot should use:

- Local component state  
- Cascading parameters for shared UI state  
- Services for shared business state  
- Event bus messages for global state changes  

Copilot must avoid:

- Static/global state  
- Storing API responses in singletons  

---

# **Code Quality Expectations**

Copilot should:

- Generate clean, readable code  
- Use async/await everywhere  
- Avoid magic strings  
- Use `ILogger<T>` for logging  
- Follow SOLID principles  
- Prefer composition over inheritance  
- Avoid static helpers unless pure functions  

---

# **Copilot Behavior Expectations**

Copilot should:

- Provide reasoning before generating code  
- Suggest multiple UI/UX options when relevant  
- Explain tradeoffs  
- Generate step‑by‑step implementation plans  
- Produce code ready for GitHub Copilot to apply  
- Maintain enterprise‑grade patterns  
- Avoid simplistic examples  

---

# **Summary**

Midland Blazor WASM applications are **pure client UIs**:

- Use **Common Models**  
- Use **Base Client Repository** for all API calls  
- Use **Event Bus** for all error and status messaging  
- Use **RestEase clients** indirectly through the repository  
- Use **Telerik UI only**  
- Use **code‑behind components**  
- Never touch backend concerns  
- Never generate DTOs, EF, UOW, repositories, binding models, or validation classes  
- Never generate token logic or HttpClient configuration  
- Never generate direct RestEase calls  
- Only consume the Base Client Repository and react to event bus messages  

Copilot must operate strictly within this frontend boundary.
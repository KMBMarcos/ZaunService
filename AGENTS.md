## AI Agents for ZaunService

ZaunService is an **ASP.NET Core MVC** app targeting **.NET 9**, using **Entity Framework Core (DB-first)** with **SQL Server**.

This file tells AI assistants (Cursor agents) how to work safely and consistently in this repo.

### Scope and goals

- **Primary goal**: keep a stable ticket workflow (create/list/assign by stage) and improve features incrementally.
- **Minimal diffs**: avoid refactors unless requested; prefer small, reviewable changes.
- **Preserve patterns**: match existing controller/view/model style and naming.

### Project map (high-signal)

- **Entry point**: `ZaunService/Program.cs` (minimal hosting, MVC, `TicketServiceContext` registration).
- **MVC controllers**: `ZaunService/Controllers/` (e.g., `TicketsController`, `ServiceController`).
- **EF Core models**: `ZaunService/Models/` (DB-first entities + `TicketServiceContext`).
- **Razor UI**: `ZaunService/Views/` (Bootstrap + tag helpers).
- **Configuration**: `ZaunService/appsettings*.json` (connection string name: `TicketServiceContext`).

### Runtime behavior to respect

- **Ticket listing**: `TicketsController.Index` loads tickets including `Service` via `Include(...)`.
- **Ticket creation screen**: `TicketsController.Create` populates services using a `SelectList`.
- **Auth**: `app.UseAuthorization()` exists, but don’t assume authentication/role guards are implemented unless you see them in code.

### Entity Framework Core (DB-first) rules

- **Use the existing context**: query via `TicketServiceContext` and keep LINQ readable.
- **Avoid destructive schema changes** unless explicitly asked (no dropping tables/columns, no mass data rewrites).
- **Do not commit secrets**:
  - Never hardcode real connection strings.
  - If scaffolding introduces a connection string in `OnConfiguring`, prefer documenting how to use `Name=TicketServiceContext` and configuration-based secrets rather than checking credentials into git.
- **Regenerating models** (when DB changes):
  - Use `Scaffold-DbContext` as documented in `README.md`.
  - After scaffolding, review entity/relationship changes (FKs, defaults, max lengths).

### Backend coding conventions

- **Controllers**: keep actions small; prefer async EF calls (`ToListAsync`, etc.).
- **Validation**:
  - Use data annotations on view models/entities only when it matches desired UX.
  - Return validation errors through standard MVC model state; don’t leak internal exceptions to the UI.
- **Error handling**: use the existing `/Home/Error` flow for unhandled errors; keep user-facing messages clear and safe.

### Razor + Bootstrap conventions

- **Prefer tag helpers** (`asp-for`, `asp-action`, `asp-controller`) and existing partials/scripts for validation.
- **Prefer Bootstrap utility classes** over custom CSS, unless the design requires custom styling.

### Testing and verification (before you finish a change)

- **Build**:
  - `dotnet build ZaunService/ZaunService.csproj`
- **Run**:
  - `dotnet run --project ZaunService`
- **Smoke checks** (manual):
  - Home page loads
  - Services list loads (`/Service`)
  - Tickets list loads (`/Tickets`)
  - Tickets create page loads and service dropdown is populated (`/Tickets/Create`)

### Repo hygiene and safety

- **Do not edit build outputs**: avoid committing changes under `ZaunService/bin/` and `ZaunService/obj/`.
- **Keep migrations cautious**: prefer DB-first regeneration over ad-hoc EF migrations unless the user requests a migrations-based approach.
- **Keep docs in sync**: update `README.md` only when behavior/setup changes.

### Communication rules (for agents)

- Default explanations in **Spanish** when the user writes Spanish; keep identifiers and code in **English**.
- Explain only non-obvious trade-offs; avoid narration-style comments in code.

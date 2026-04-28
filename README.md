[![Ask DeepWiki](https://deepwiki.com/badge.svg)](https://deepwiki.com/KMBMarcos/ZaunService)

# ZaunService

Plataforma de gestión de solicitudes de soporte técnico mediante tickets para Zaun. Permite a los usuarios registrar solicitudes a través de un formulario, las cuales son gestionadas y resueltas por los equipos internos siguiendo un flujo de atención estructurado.

## Flujo de atención

```
Formulario  →  Atención al Usuario (AU)  →  Dirección Técnica (DT)  →  Atención al Usuario (AU)
```

1. **Formulario** — El usuario externo completa y envía su solicitud para una evaluación.
2. **Atención al Usuario (AU)** — Recibe, revisa y registra la solicitud. Si requiere intervención técnica, la escala.
3. **Dirección Técnica (DT)** — Analiza y resuelve la solicitud técnica.
4. **Atención al Usuario (AU)** — Recibe la resolución y notifica/cierra la solicitud ante el usuario.

## Funcionalidades actuales

- Registro de tickets mediante formulario (servicio + descripción de la solicitud)
- Listado de tickets con número, servicio asociado, mensaje, estado y fecha de creación
- Catálogo de servicios disponibles
- Modelo de datos con soporte para asignaciones de tickets por etapas (`TicketAssignment`)
- Gestión de usuarios con roles (`User.Role`)

## Funcionalidades planificadas

- Campos adicionales en el formulario de solicitud: institución, provincia, municipio, sector, teléfono, celular y correo electrónico
- Acción de creación de tickets (POST) con validación
- Sistema de autenticación y autorización por roles (AU / DT)
- Panel de administración para Atención al Usuario
- Panel de gestión para Dirección Técnica
- Seguimiento de etapas del ticket (`Stage`) y asignación a administradores
- Notificaciones al usuario sobre el estado de su solicitud

## Stack tecnológico

- **Framework:** ASP.NET Core MVC (.NET 9.0)
- **ORM:** Entity Framework Core 9.0 (Database-First)
- **Base de datos:** Microsoft SQL Server
- **Frontend:** Razor Views + Bootstrap

## Requisitos previos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (local o remoto)
- Visual Studio 2022 o Visual Studio Code

## Configuración

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/KMBMarcos/ZaunService.git
   ```

2. Configurar la cadena de conexión en `ZaunService/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "TicketServiceContext": "Server=TU_SERVIDOR;Database=TicketService;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```

3. Ejecutar la aplicación:
   ```bash
   dotnet run --project ZaunService
   ```

## Estructura del proyecto

```
ZaunService/
├── Controllers/
│   ├── HomeController.cs
│   ├── ServiceController.cs
│   └── TicketsController.cs
├── Models/
│   ├── Ticket.cs
│   ├── Service.cs
│   ├── User.cs
│   ├── TicketAssignment.cs
│   ├── TicketServiceContext.cs
│   └── ViewModels/
│       └── TicketsViewModel.cs
└── Views/
    ├── Home/
    ├── Service/
    └── Tickets/
```

## Actualizar el modelo desde la base de datos

Si la base de datos cambia, regenerar los modelos con:

```powershell
Scaffold-DbContext "Server=TU_SERVIDOR;Database=TicketService;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
```

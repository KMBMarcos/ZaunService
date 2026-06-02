# ZaunService

Plataforma de gestión de solicitudes de soporte técnico mediante tickets para Zaun. Permite a los usuarios registrar solicitudes a través de un formulario, las cuales son gestionadas y resueltas por los equipos internos siguiendo un flujo de atención estructurado.

Arquitectura basada en **.NET Aspire** que orquesta un backend con APIs minimalistas y un frontend SPA en React.

## Arquitectura

```
┌─────────────────────────────────────────────────────────┐
│              .NET Aspire Orchestrator                   │
│               (ZaunServices.AppHost)                    │
│                                                         │
│  ┌──────────────────┐  ┌──────────────┐  ┌───────────┐  │
│  │  ZaunServices    │  │   Redis      │  │PostgreSQL │  │
│  │  .Server         │◄─┤   (cache)    │  │(datos)    │  │
│  │  (Minimal API)   │  └──────────────┘  └───────────┘  │
│  └───────┬──────────┘                                   │
│          │ HTTP                                         │
│  ┌───────┴──────────┐                                   │
│  │    frontend/     │                                   │
│  │  (React + Vite)  │                                   │
│  └──────────────────┘                                   │
└─────────────────────────────────────────────────────────┘
```

- **ZaunServices.AppHost** — Orquestador de Aspire; provisiona Redis, PostgreSQL, y coordina el ciclo de vida del backend y frontend.
- **ZaunServices.Server** — Backend con APIs minimalistas (`/api/*`), output caching con Redis, OpenTelemetry, y sirve el frontend SPA como archivos estáticos.
- **frontend/** — SPA en React 19 + TypeScript + Vite.

## Stack tecnológico

| Capa | Tecnología | Versión |
|---|---|---|
| **Orquestación** | .NET Aspire SDK | 13.2.4 |
| **Backend runtime** | .NET | 9.0 |
| **Backend framework** | ASP.NET Core Minimal API | 9.0 |
| **Frontend** | React | 19.2.1 |
| **Lenguaje frontend** | TypeScript | ~5.9 |
| **Bundler** | Vite | 8.0 |
| **Cache** | Redis (via Aspire) | — |
| **Base de datos** | PostgreSQL (via Aspire + pgAdmin) | 13.4.0 |
| **OpenAPI docs** | Microsoft.AspNetCore.OpenApi | 9.0.14 |
| **Telemetría** | OpenTelemetry (OTLP, ASP.NET Core, HTTP, Runtime) | 1.15.x |
| **Resiliencia HTTP** | Microsoft.Extensions.Http.Resilience | 10.2.0 |
| **Service Discovery** | Microsoft.Extensions.ServiceDiscovery | 10.2.0 |

## Flujo de atención (modelo de negocio)

```
Formulario  →  Atención al Usuario (AU)  →  Dirección Técnica (DT)  →  Atención al Usuario (AU)
```

1. **Formulario** — El usuario externo completa y envía su solicitud para una evaluación.
2. **Atención al Usuario (AU)** — Recibe, revisa y registra la solicitud. Si requiere intervención técnica, la escala.
3. **Dirección Técnica (DT)** — Analiza y resuelve la solicitud técnica.
4. **Atención al Usuario (AU)** — Recibe la resolución y notifica/cierra la solicitud ante el usuario.

## Funcionalidades actuales

- Arquitectura .NET Aspire con orquestación de contenedores (Redis, PostgreSQL)
- Backend con endpoints minimalistas y output caching
- Frontend SPA con React + TypeScript + Vite
- Telemetría y health checks integrados

> **Nota:** El proyecto está en migración desde ASP.NET Core MVC clásico hacia .NET Aspire. La lógica de negocio (tickets, servicios, usuarios) está siendo trasladada desde la versión anterior.

## Funcionalidades planificadas

- Registro de tickets mediante formulario (servicio + descripción de la solicitud)
- Listado de tickets con número, servicio asociado, mensaje, estado y fecha de creación
- Catálogo de servicios disponibles
- Modelo de datos con soporte para asignaciones de tickets por etapas
- Gestión de usuarios con roles
- Sistema de autenticación y autorización por roles (AU / DT)
- Panel de administración para Atención al Usuario
- Panel de gestión para Dirección Técnica
- Seguimiento de etapas del ticket y asignación a administradores
- Notificaciones al usuario sobre el estado de su solicitud

## Requisitos previos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (para Redis y PostgreSQL vía Aspire)
- [Node.js ^20.19 o >=22.12](https://nodejs.org/)
- Visual Studio 2022 o Visual Studio Code

## Configuración y ejecución

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/KMBMarcos/ZaunService.git
   ```

2. Ejecutar la aplicación Aspire (levanta backend, frontend, Redis y PostgreSQL automáticamente):
   ```bash
   dotnet run --project ZaunServices/ZaunServices.AppHost
   ```

   La primera vez puede tardar mientras se descargan las imágenes Docker y las dependencias npm.

## Estructura del proyecto

```
ZaunServices/
├── ZaunServices.AppHost/          # Orquestador .NET Aspire
│   ├── AppHost.cs                 # Declaración de recursos (Redis, Postgres, server, frontend)
│   ├── appsettings.json
│   └── Properties/launchSettings.json
├── ZaunServices.Server/           # Backend Minimal API
│   ├── Program.cs                 # Punto de entrada y definición de endpoints
│   ├── Extensions.cs              # Service defaults (OpenTelemetry, health checks)
│   ├── appsettings.json
│   └── Properties/launchSettings.json
├── frontend/                      # Frontend SPA (React + Vite + TypeScript)
│   ├── src/
│   │   ├── main.tsx
│   │   └── App.tsx
│   ├── index.html
│   ├── package.json
│   ├── vite.config.ts
│   └── tsconfig*.json
└── ZaunServices.slnx              # Solution file (formato .NET Aspire)
```

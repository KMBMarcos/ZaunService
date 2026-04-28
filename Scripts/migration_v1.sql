-- ============================================================
-- ZaunService - Migración v1
-- Ejecutar en la base de datos: TicketService
-- ============================================================

-- 1. Nuevos campos de contacto en la tabla tickets
ALTER TABLE tickets ADD
    nombre_solicitante  NVARCHAR(255) NULL,
    institucion         NVARCHAR(255) NULL,
    provincia           NVARCHAR(100) NULL,
    municipio           NVARCHAR(100) NULL,
    sector              NVARCHAR(100) NULL,
    telefono            NVARCHAR(20)  NULL,
    celular             NVARCHAR(20)  NULL,
    correo_contacto     NVARCHAR(255) NULL;

-- 2. Campo de notas en asignaciones (usado por DT al resolver)
ALTER TABLE ticket_assignments ADD
    notes NVARCHAR(MAX) NULL;

-- 3. Campo de contraseña en usuarios del sistema (AU / DT)
ALTER TABLE users ADD
    password_hash NVARCHAR(255) NULL;

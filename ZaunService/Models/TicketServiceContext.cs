/* 
Generado con el comando NuGet Package CLI: 
    Scaffold-DbContext "Server=DESKTOP-1JS1MQK;Database=TicketService;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

Para actualizar, utilizar el comando:
    Scaffold-DbContext "Server=DESKTOP-1JS1MQK;Database=TicketService;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
*/

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ZaunService.Models;

public partial class TicketServiceContext : DbContext
{
    public TicketServiceContext()
    {
    }

    public TicketServiceContext(DbContextOptions<TicketServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketAssignment> TicketAssignments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1JS1MQK;Database=TicketService;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__services__3213E83F10B9BCF0");

            entity.ToTable("services");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tickets__3213E83F360394C7");

            entity.ToTable("tickets");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("new")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Service).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__tickets__service__3E52440B");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__tickets__user_id__3D5E1FD2");
        });

        modelBuilder.Entity<TicketAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ticket_a__3213E83F1E1467EA");

            entity.ToTable("ticket_assignments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.AssignedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("assigned_at");
            entity.Property(e => e.Stage).HasColumnName("stage");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");

            entity.HasOne(d => d.Admin).WithMany(p => p.TicketAssignments)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__ticket_as__admin__45F365D3");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketAssignments)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__ticket_as__ticke__44FF419A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FD96E6398");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E61645AC631A4").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

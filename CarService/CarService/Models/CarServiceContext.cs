using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarService.Models;

public partial class CarServiceContext : DbContext
{
    public CarServiceContext()
    {
    }

    public CarServiceContext(DbContextOptions<CarServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarClient> CarClients { get; set; }

    public virtual DbSet<CarZapchast> CarZapchasts { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Work> Works { get; set; }

    public virtual DbSet<WorkZakazNaryad> WorkZakazNaryads { get; set; }

    public virtual DbSet<ZakazNaryad> ZakazNaryads { get; set; }

    public virtual DbSet<Zapchast> Zapchasts { get; set; }

    public virtual DbSet<ZapchastZakazNaryad> ZapchastZakazNaryads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = CarService; Integrated Security = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.ToTable("Car");

            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.Marka).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.TypeEngine)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<CarClient>(entity =>
        {
            entity.ToTable("CarClient");

            entity.Property(e => e.CarClientId).HasColumnName("CarClientID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.DateRegistration).HasColumnType("date");
            entity.Property(e => e.Marka).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.StateNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TypeEngine)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Vin).HasMaxLength(50);

            entity.HasOne(d => d.Client).WithMany(p => p.CarClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarClient_Client");
        });

        modelBuilder.Entity<CarZapchast>(entity =>
        {
            entity.ToTable("CarZapchast");

            entity.Property(e => e.CarZapchastId).HasColumnName("CarZapchastID");
            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.ZapchatId).HasColumnName("ZapchatID");

            entity.HasOne(d => d.Car).WithMany(p => p.CarZapchasts)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarZapchast_Car");

            entity.HasOne(d => d.Zapchat).WithMany(p => p.CarZapchasts)
                .HasForeignKey(d => d.ZapchatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarZapchast_Zapchast");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fio)
                .HasMaxLength(100)
                .HasColumnName("FIO");
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(12)
                .IsFixedLength();
        });

        modelBuilder.Entity<Work>(entity =>
        {
            entity.ToTable("Work");

            entity.Property(e => e.WorkId).HasColumnName("WorkID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<WorkZakazNaryad>(entity =>
        {
            entity.ToTable("WorkZakazNaryad");

            entity.Property(e => e.WorkZakazNaryadId).HasColumnName("WorkZakazNaryadID");
            entity.Property(e => e.WorkId).HasColumnName("WorkID");
            entity.Property(e => e.ZakazNaryadId).HasColumnName("ZakazNaryadID");

            entity.HasOne(d => d.Work).WithMany(p => p.WorkZakazNaryads)
                .HasForeignKey(d => d.WorkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkZakazNaryad_Work");

            entity.HasOne(d => d.ZakazNaryad).WithMany(p => p.WorkZakazNaryads)
                .HasForeignKey(d => d.ZakazNaryadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkZakazNaryad_ZakazNaryad1");
        });

        modelBuilder.Entity<ZakazNaryad>(entity =>
        {
            entity.ToTable("ZakazNaryad");

            entity.Property(e => e.ZakazNaryadId).HasColumnName("ZakazNaryadID");
            entity.Property(e => e.CarClientId).HasColumnName("CarClientID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.WorkZakazNaryadId).HasColumnName("WorkZakazNaryadID");
            entity.Property(e => e.ZapchastZakazNaryadId).HasColumnName("ZapchastZakazNaryadID");

            entity.HasOne(d => d.CarClient).WithMany(p => p.ZakazNaryads)
                .HasForeignKey(d => d.CarClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZakazNaryad_CarClient");

            entity.HasOne(d => d.Client).WithMany(p => p.ZakazNaryads)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZakazNaryad_Client");
        });

        modelBuilder.Entity<Zapchast>(entity =>
        {
            entity.ToTable("Zapchast");

            entity.Property(e => e.ZapchastId).HasColumnName("ZapchastID");
            entity.Property(e => e.Manufacturer).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ZapchastZakazNaryad>(entity =>
        {
            entity.ToTable("ZapchastZakazNaryad");

            entity.Property(e => e.ZapchastZakazNaryadId).HasColumnName("ZapchastZakazNaryadID");
            entity.Property(e => e.ZakazNaryadId).HasColumnName("ZakazNaryadID");
            entity.Property(e => e.ZapchastId).HasColumnName("ZapchastID");

            entity.HasOne(d => d.ZakazNaryad).WithMany(p => p.ZapchastZakazNaryads)
                .HasForeignKey(d => d.ZakazNaryadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZapchastZakazNaryad_ZakazNaryad1");

            entity.HasOne(d => d.Zapchast).WithMany(p => p.ZapchastZakazNaryads)
                .HasForeignKey(d => d.ZapchastId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZapchastZakazNaryad_Zapchast");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

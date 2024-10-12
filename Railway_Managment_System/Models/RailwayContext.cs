using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Railway_Managment_System.Models;

public partial class RailwayContext : DbContext
{
    public RailwayContext()
    {
    }

    public RailwayContext(DbContextOptions<RailwayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CancelTicket> CancelTickets { get; set; }

    public virtual DbSet<ClassRate> ClassRates { get; set; }

    public virtual DbSet<FareDetail> FareDetails { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-757BGI8\\SQLEXPRESS;initial catalog=railway;user id=abc;password=shaheer; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CancelTicket>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__CancelTi__213EE774ADED7BF3");

            entity.ToTable("CancelTicket");

            entity.Property(e => e.CId).HasColumnName("c_id");
            entity.Property(e => e.PassengerEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("passenger_email");
            entity.Property(e => e.PassengerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("passenger_name");
        });

        modelBuilder.Entity<ClassRate>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__ClassRat__CB1927C0AF6C12C9");

            entity.ToTable("ClassRate");

            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClassRate1).HasColumnName("ClassRate");
        });

        modelBuilder.Entity<FareDetail>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__fare_det__2911CBED03CDDCA0");

            entity.ToTable("fare_detail");

            entity.Property(e => e.FId).HasColumnName("f_id");
            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.TrainId).HasColumnName("train_id");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__login__3213E83F8F3A7B69");

            entity.ToTable("login");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Roletype).HasColumnName("roletype");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__ticket__D596F96B890021B3");

            entity.ToTable("ticket");

            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Class)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("class");
            entity.Property(e => e.DateOfTarvel).HasColumnName("date_of_tarvel");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Passengers).HasColumnName("passengers");
            entity.Property(e => e.TotalFair).HasColumnName("total_fair");
            entity.Property(e => e.TrainId).HasColumnName("train_id");

            entity.HasOne(d => d.Train).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__ticket__train_id__6E01572D");
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__trains__3213E83F3C2494ED");

            entity.ToTable("trains");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Arrival)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("arrival");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Departure)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("departure");
            entity.Property(e => e.DepartureTime).HasColumnName("departure_time");
            entity.Property(e => e.General).HasColumnName("general");
            entity.Property(e => e.OneAc).HasColumnName("one_ac");
            entity.Property(e => e.Sleeper).HasColumnName("sleeper");
            entity.Property(e => e.ThreeAc).HasColumnName("three_ac");
            entity.Property(e => e.TrainName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("train_name");
            entity.Property(e => e.TwoAc).HasColumnName("two_ac");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

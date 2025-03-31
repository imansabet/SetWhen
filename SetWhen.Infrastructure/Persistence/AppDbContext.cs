using Microsoft.EntityFrameworkCore;
using SetWhen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetWhen.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<StaffAvailability> StaffAvailabilities => Set<StaffAvailability>();
    public DbSet<Business> Businesses => Set<Business>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Entity<StaffAvailability>().OwnsOne(sa => sa.TimeRange);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Service)
            .WithMany()
            .HasForeignKey(r => r.ServiceId);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Staff)
            .WithMany()
            .HasForeignKey(r => r.StaffId);

        modelBuilder.Entity<Business>()
            .HasOne(b => b.Owner)
            .WithMany()
            .HasForeignKey(b => b.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Service>()
            .HasOne(s => s.Owner)
            .WithMany()
            .HasForeignKey(s => s.OwnerId);
    }
}

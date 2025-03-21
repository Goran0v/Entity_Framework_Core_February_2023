﻿namespace Trucks.Data
{
    using Microsoft.EntityFrameworkCore;
    using Trucks.Data.Models;

    public class TrucksContext : DbContext
    {
        public TrucksContext()
        { 
        }

        public TrucksContext(DbContextOptions options)
            : base(options)
        { 
        }

        public DbSet<Truck> Trucks { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Despatcher> Despatchers { get; set; } = null!;
        public DbSet<ClientTruck> ClientsTrucks { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientTruck>()
                .HasKey(p => new { p.ClientId, p.TruckId });
        }
    }
}

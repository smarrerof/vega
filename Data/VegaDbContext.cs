using Microsoft.EntityFrameworkCore;
using WebApplicationBasic.Data.Models;

namespace WebApplicationBasic.Data
{
    public class VegaDbContext : DbContext 
    {
        public DbSet<Feature> Features { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        public VegaDbContext(DbContextOptions<VegaDbContext> options) 
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Vehicle>()
                .HasOne(m => m.Make)
                .WithMany(n => n.Vehicles)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasOne(m => m.Model)
                .WithMany(n => n.Vehicles)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleFeature>()
                .HasKey(m => new { m.VehicleId, m.FeatureId });
        }
    }
}
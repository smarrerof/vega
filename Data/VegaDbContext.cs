using Microsoft.EntityFrameworkCore;
using WebApplicationBasic.Data.Models;

namespace WebApplicationBasic.Data
{
    public class VegaDbContext : DbContext {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) 
            : base(options) { }

        public DbSet<Feature> Features { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
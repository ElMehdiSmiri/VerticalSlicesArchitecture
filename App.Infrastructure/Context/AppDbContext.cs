using App.Domain.Entities;
using App.Infrastructure.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Country> Countries => Set<Country>();
        public virtual DbSet<City> Cities => Set<City>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CityEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

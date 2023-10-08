using App.Domain.Entities;
using App.Infrastructure.Common.Extensions;
using App.Infrastructure.EntitiesConfiguration;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Context
{
    public class AppDbContext : BaseDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : base(options, mediator)
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

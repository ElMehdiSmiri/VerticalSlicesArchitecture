using App.Domain.Entities;
using App.Infrastructure.Common.Extensions;
using App.Infrastructure.EntitiesConfiguration;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) 
        : BaseDbContext(options, mediator)
    {
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

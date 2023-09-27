using App.Domain.Entities;
using App.Infrastructure.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EntitiesConfiguration
{
    public class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ConfigureIdWithDbGeneratedValue();

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Language)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Population)
                .IsRequired();

            builder.HasMany(x => x.Cities)
               .WithOne(x => x.Country)
               .HasForeignKey(x => x.CountryId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

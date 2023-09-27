using App.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Common.Extensions
{
    public static class EntityConfigurationExtension
    {
        public static void ConfigureId<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .IsRequired();
        }

        public static void ConfigureIdWithDbGeneratedValue<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.ConfigureId();
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();
        }

        public static void ConfigureIdWithDefaultAndValueGeneratedNever<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.ConfigureId();
            builder.Property(x => x.Id)
                .ValueGeneratedNever();
        }
    }
}

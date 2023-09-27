using App.Domain.Common;
using Dawn;

namespace App.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; } = default!;
        public int Population { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; } = default!;

        protected City() { }

        public City(string name, int population, Country country)
        {
            Name = Guard.Argument(name, nameof(name))
                .NotEmpty()
                .MaxLength(100);

            Population = Guard.Argument(population, nameof(population))
                .Min(1);

            Country = Guard.Argument(country, nameof(country))
                .NotNull();
        }

        public void Update(string name, int population)
        {
            Name = Guard.Argument(name, nameof(name))
                .NotEmpty()
                .MaxLength(100);

            Population = Guard.Argument(population, nameof(population))
                .Min(1);
        }
    }
}

using App.Domain.Common;
using App.Domain.Events;
using Dawn;

namespace App.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Language { get; set; } = default!;
        public int Population { get; set; }
        public virtual ICollection<City> Cities { get; set; } = new List<City>();

        public Country(string name, string language, int population)
        {
            Name = Guard.Argument(name, nameof(name))
                .NotNull()
                .NotEmpty()
                .MaxLength(100);

            Language = Guard.Argument(language, nameof(language))
                .NotNull()
                .NotEmpty()
                .MaxLength(100);

            Population = Guard.Argument(population, nameof(population))
                .Min(0);
        }

        public void Update(string name, string language, int population)
        {
            Name = Guard.Argument(name, nameof(name))
                .NotEmpty()
                .MaxLength(100);
            Language = Guard.Argument(language, nameof(language))
                .NotEmpty()
                .MaxLength(100);
            Population = Guard.Argument(population, nameof(population))
                .Min(0);
        }

        public void AddCity(City city)
        {
            if (Cities.Any(x => x.Name == city.Name))
                throw new ArgumentException($"A city with the name {city.Name} already exist in {Name}");

            Cities.Add(city);

            AddDomainEvent(new CityAdded(city));
        }

        public void RemoveCity(City city)
        {
            if (!Cities.Any(x => x.Name == city.Name))
                throw new ArgumentException($"A city with the name {city.Name} does not exist in {Name}");

            Cities.Remove(city);
        }
    }
}

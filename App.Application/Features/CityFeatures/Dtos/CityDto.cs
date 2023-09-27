using App.Application.Features.CountryFeatures.Dtos;
using App.Domain.Entities;

namespace App.Application.Features.CityFeatures.Dtos
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public int Population { get; set; }
        public Guid CountryId { get; set; }
        public CountryDto? Country { get; set; } = default!;
    }

    public static class CityExtensions
    {
        public static CityDto Map(this City city, bool mapCountry = false)
        {
            return new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                Population = city.Population,
                CountryId = city.CountryId,
                Country = mapCountry ? city.Country.Map() : null
            };
        }
    }
}

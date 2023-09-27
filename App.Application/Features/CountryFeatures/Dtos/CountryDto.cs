using App.Application.Features.CityFeatures.Dtos;
using App.Domain.Entities;

namespace App.Application.Features.CountryFeatures.Dtos
{
    public class CountryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Language { get; set; } = default!;
        public int Population { get; set; }
        public List<CityDto> Cities { get; set; } = new List<CityDto>();
    }

    public static class CountryExtensions
    {
        public static CountryDto Map(this Country country, bool mapCities = false)
        {
            return new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
                Language = country.Language,
                Population = country.Population,
                Cities = mapCities ? country.Cities.Select(x => x.Map()).ToList() : new List<CityDto>()
            };
        }
    }
}

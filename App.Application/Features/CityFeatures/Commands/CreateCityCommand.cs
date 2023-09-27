using App.Application.Common.Extensions;
using App.Domain.Entities;
using App.Infrastructure.Context;
using MediatR;

namespace App.Application.Features.CityFeatures.Commands
{
    public record CreateCityCommand(Guid CountryId, string Name, int Population) : IRequest<Guid>;

    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Guid>
    {
        private readonly AppDbContext _dbContext;

        public CreateCityCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var country = await _dbContext.Countries.GetNonNullableByIdAsync(request.CountryId, cancellationToken);
            var city = new City(request.Name, request.Population, country);
            country.AddCity(city);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return city.Id;
        }
    }
}

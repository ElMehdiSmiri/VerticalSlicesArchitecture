using App.Application.Common.Extensions;
using App.Infrastructure.Context;
using MediatR;

namespace App.Application.Features.CityFeatures.Commands
{
    public record DeleteCityCommand(Guid CountryId, Guid Id) : IRequest<Guid>;

    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Guid>
    {
        private readonly AppDbContext _dbContext;

        public DeleteCityCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var country = await _dbContext.Countries.GetNonNullableByIdAsync(request.CountryId, cancellationToken);
            var city = await _dbContext.Cities.GetNonNullableByIdAsync(request.Id, cancellationToken);

            country.RemoveCity(city);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return city.Id;
        }
    }
}

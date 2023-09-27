using App.Application.Common.Extensions;
using App.Infrastructure.Context;
using MediatR;

namespace App.Application.Features.CityFeatures.Commands
{
    public record EditCityCommand(Guid CountryId, Guid Id, string Name, int Population) : IRequest<Guid>;

    public class EditCityCommandHandler : IRequestHandler<EditCityCommand, Guid>
    {
        private readonly AppDbContext _dbContext;

        public EditCityCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(EditCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _dbContext.Cities.GetNonNullableByIdAsync(request.Id, cancellationToken);

            city.Update(request.Name, request.Population);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return city.Id;
        }
    }
}

using App.Domain.Entities;
using App.Infrastructure.Context;
using MediatR;

namespace App.Application.Features.CountryFeatures.Commands
{
    public record CreateCountryCommand(string Name, string Language, int Population) : IRequest<Guid>;

    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Guid>
    {
        private readonly AppDbContext _dbContext;

        public CreateCountryCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = new Country(request.Name, request.Language, request.Population);

            _dbContext.Countries.Add(country);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return country.Id;
        }
    }
}

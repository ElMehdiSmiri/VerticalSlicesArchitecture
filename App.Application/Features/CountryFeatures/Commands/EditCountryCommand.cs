using App.Application.Common.Extensions;
using App.Infrastructure.Context;
using MediatR;

namespace App.Application.Features.CountryFeatures.Commands
{
    public record EditCountryCommand(Guid Id, string Name, string Language, int Population) : IRequest<Guid>;

    public class EditCountryCommandHandler : IRequestHandler<EditCountryCommand, Guid>
    {
        private readonly AppDbContext _dbContext;

        public EditCountryCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(EditCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _dbContext.Countries.GetNonNullableByIdAsync(request.Id, cancellationToken);

            country.Update(request.Name, request.Language, request.Population);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return country.Id;
        }
    }
}

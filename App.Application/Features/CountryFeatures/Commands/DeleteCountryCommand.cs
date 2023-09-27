using App.Application.Common.Extensions;
using App.Infrastructure.Context;
using MediatR;

namespace App.Application.Features.CountryFeatures.Commands
{
    public record DeleteCountryCommand(Guid Id) : IRequest<Guid>;

    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Guid>
    {
        private readonly AppDbContext _dbContext;

        public DeleteCountryCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _dbContext.Countries.GetNonNullableByIdAsync(request.Id, cancellationToken);

            _dbContext.Countries.Remove(country);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return country.Id;
        }
    }
}

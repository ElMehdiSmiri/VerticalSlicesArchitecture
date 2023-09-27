using App.Application.Common.Extensions;
using App.Application.Features.CountryFeatures.Dtos;
using App.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Features.CountryFeatures.Queries
{
    public record GetCoutryByIdQuery(Guid Id) : IRequest<CountryDto>;

    public class GetCoutryByIdQueryHandler : IRequestHandler<GetCoutryByIdQuery, CountryDto>
    {
        private readonly AppDbContext _dbContext;

        public GetCoutryByIdQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CountryDto> Handle(GetCoutryByIdQuery request, CancellationToken cancellationToken)
        {
            return (await _dbContext.Countries
                .AsNoTracking()
                .Include(x => x.Cities)
                .GetNonNullableByIdAsync(request.Id, cancellationToken))
                .Map(true);
        }
    }
}

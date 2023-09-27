using App.Application.Features.CountryFeatures.Dtos;
using App.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Features.CountryFeatures.Queries
{
    public record GetCountriesQuery() : IRequest<List<CountryDto>>;

    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, List<CountryDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetCountriesQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Countries
                .AsNoTracking()
                .Select(x => x.Map(false))
                .ToListAsync(cancellationToken);
        }
    }
}

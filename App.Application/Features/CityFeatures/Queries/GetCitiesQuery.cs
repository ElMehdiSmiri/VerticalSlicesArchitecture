using App.Application.Features.CityFeatures.Dtos;
using App.Application.Features.CountryFeatures.Dtos;
using App.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Features.CityFeatures.Queries
{

    public record GetCitiesQuery() : IRequest<List<CityDto>>;

    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, List<CityDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetCitiesQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CityDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Cities
                .AsNoTracking()
                .Select(x => x.Map(false))
                .ToListAsync(cancellationToken);
        }
    }
}

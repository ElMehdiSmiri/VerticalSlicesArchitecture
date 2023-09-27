using App.Application.Features.CityFeatures.Dtos;
using App.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Features.CityFeatures.Queries
{
    public record GetCitiesByCountryIdQuery(Guid CountryId) : IRequest<List<CityDto>>;

    public class GetCitiesByCountryIdQueryHandler : IRequestHandler<GetCitiesByCountryIdQuery, List<CityDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetCitiesByCountryIdQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CityDto>> Handle(GetCitiesByCountryIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Cities
                .AsNoTracking()
                .Where(x => x.CountryId == request.CountryId)
                .Select(x => x.Map(false))
                .ToListAsync(cancellationToken);
        }
    }
}

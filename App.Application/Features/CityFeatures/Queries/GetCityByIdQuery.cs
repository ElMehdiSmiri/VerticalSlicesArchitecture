using App.Application.Common.Extensions;
using App.Application.Features.CityFeatures.Dtos;
using App.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Features.CityFeatures.Queries
{
    public record GetCityByIdQuery(Guid CountryId, Guid Id) : IRequest<CityDto>;

    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDto>
    {
        private readonly AppDbContext _dbContext;

        public GetCityByIdQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            return (await _dbContext.Cities
                .AsNoTracking()
                .Include(x => x.Country)
                .SingleAsync(x => x.Id == request.Id && x.CountryId == request.CountryId, cancellationToken))
                .Map(true);
        }
    }

}

using App.Infrastructure.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Features.CityFeatures.Commands.Validators
{
    public class DeleteCityCommandValidator : AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityCommandValidator(AppDbContext dbContext)
        {
            RuleFor(x => x.CountryId)
                .NotEmpty()
                .MustAsync(async (counryId, cancellationToken) =>
                {
                    return await dbContext.Countries.AnyAsync(x => x.Id == counryId, cancellationToken);
                })
                .WithMessage("Country does not exist.");

            RuleFor(x => x.Id)
                .NotEmpty()
                .MustAsync(async (cmd, id, cancellationToken) =>
                {
                    return await dbContext.Cities.AnyAsync(x => x.Id == id && x.CountryId == cmd.CountryId, cancellationToken);
                })
                .WithMessage("City does not exist.");
        }
    }
}

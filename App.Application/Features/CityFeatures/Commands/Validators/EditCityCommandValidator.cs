using App.Infrastructure.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Features.CityFeatures.Commands.Validators
{
    public class EditCityCommandValidator : AbstractValidator<EditCityCommand>
    {
        public EditCityCommandValidator(AppDbContext dbContext)
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
                .MustAsync(async (id, cancellationToken) =>
                {
                    return await dbContext.Cities.AnyAsync(x => x.Id == id, cancellationToken);
                })
                .WithMessage("City does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100)
                .MustAsync(async (cmd, name, cancellationToken) =>
                {
                    return !await dbContext.Cities.AnyAsync(x => x.CountryId == cmd.CountryId && x.Id != cmd.Id && x.Name == name, cancellationToken);
                })
                .WithMessage("A city with this name already exist in this country.");

            RuleFor(x => x.Population)
                .GreaterThan(0);
        }
    }
}

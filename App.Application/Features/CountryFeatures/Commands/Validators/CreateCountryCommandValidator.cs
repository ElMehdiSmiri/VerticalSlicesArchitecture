using FluentValidation;

namespace App.Application.Features.CountryFeatures.Commands.Validators
{
    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Language)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Population)
                .GreaterThan(0);
        }
    }
}

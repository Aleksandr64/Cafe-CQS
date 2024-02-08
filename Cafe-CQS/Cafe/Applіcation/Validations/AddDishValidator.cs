using Cafe.Domain.DTOs;
using FluentValidation;

namespace Cafe.Applіcation.Validations;

public class AddDishValidator : AbstractValidator<AddDishRequest>
{
    public AddDishValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty();

        RuleFor(x => x.Price)
            .NotEmpty();

        RuleFor(x => x.ImageUrl)
            .NotEmpty()
            .Must(BeAValidUrl).WithMessage("Image URL must be a valid URL.");
    }

    private bool BeAValidUrl(string url)
    {
        return string.IsNullOrWhiteSpace(url) || Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}
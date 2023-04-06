using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace VeeArc.Application.Feature.Images.Create;

public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand>
{
    private static readonly string[] AllowedExtensions = { ".png", ".jpg" };

    public CreateImageCommandValidator()
    {
        RuleFor(v => v.Image)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(IsValidExtensions)
            .WithMessage("Invalid file extension.");
    }

    private static bool IsValidExtensions(IFormFile image)
    {
        string extension = Path.GetExtension(image.FileName).ToLowerInvariant();
        bool result = AllowedExtensions.Contains(extension);

        return result;
    }
}

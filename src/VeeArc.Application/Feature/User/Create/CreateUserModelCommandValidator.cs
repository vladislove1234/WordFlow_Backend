using FluentValidation;

namespace VeeArc.Application.Feature.User.Create;

public class CreateUserModelCommandValidator : AbstractValidator<CreateUserModelCommand>
{
    public CreateUserModelCommandValidator()
    {
        RuleFor(user => user.FirstName)
            .MaximumLength(25)
            .NotEmpty();

        RuleFor(user => user.LastName)
            .MaximumLength(25)
            .NotEmpty();
        
        RuleFor(user => user.Email)
            .EmailAddress()
            .NotEmpty();

        RuleFor(user => user.Password)
            .MaximumLength(200)
            .MinimumLength(8);
        
        RuleFor(user => user.Username)
            .MaximumLength(100)
            .MinimumLength(4);
    }
}
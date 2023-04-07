using FluentValidation;

namespace VeeArc.Application.Feature.User.Update;

public class UpdateUserModelCommandValidator : AbstractValidator<UpdateUserModelCommand>
{
    public UpdateUserModelCommandValidator()
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
    }
}
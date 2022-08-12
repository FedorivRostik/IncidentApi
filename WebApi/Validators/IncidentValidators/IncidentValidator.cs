using Core.ViewModels.IncidentViewModels;
using FluentValidation;

namespace WebApi.Validators.IncidentValidators
{
    public class IncidentValidator: AbstractValidator<IncidentCreateModel>
    {
        public IncidentValidator()
        {
            RuleFor(c => c.FirstName)
               .MinimumLength(2)
              .WithMessage("First name must be at least 2 character long")
              .MaximumLength(50)
              .WithMessage("First name must be less than 50 characters");

            RuleFor(c => c.LastName)
                 .MinimumLength(2)
                .WithMessage("Last name must be at least 2 character long")
                .MaximumLength(50)
                .WithMessage("Last name must be less than 50 characters");

            RuleFor(c => c.Name)
                 .MinimumLength(2)
                .WithMessage("Name must be at least 2 character long")
                .MaximumLength(50)
                .WithMessage("Name must be less than 50 characters");

            RuleFor(c => c.Description)
                 .MinimumLength(10)
                .WithMessage("Description must be at least 10 character long")
                .MaximumLength(300)
                .WithMessage("Description must be less than 300 characters");

            RuleFor(c => c.Email)
               .NotEmpty()
               .WithMessage("Email is required")
               .EmailAddress()
               .WithMessage("Incorrect Email format");
        }
    }
}

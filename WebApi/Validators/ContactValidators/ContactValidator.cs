using Core.Entities;
using FluentValidation;

namespace WebApi.Validators.ContactValidators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c=>c.FirstName)
                 .MinimumLength(2)
                .WithMessage("First name must be at least 2 character long")
                .MaximumLength(50)
                .WithMessage("First name must be less than 50 characters");

            RuleFor(c=>c.LastName)
                 .MinimumLength(2)
                .WithMessage("Last name must be at least 2 character long")
                .MaximumLength(50)
                .WithMessage("Last name must be less than 50 characters");

            RuleFor(c => c.Email)
               .NotEmpty()
               .WithMessage("Email is required")
               .EmailAddress()
               .WithMessage("Incorrect Email format");
        }
    }
}

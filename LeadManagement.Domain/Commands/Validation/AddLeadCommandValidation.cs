using FluentValidation;

namespace LeadManagement.Domain.Commands.Validation;

public class AddLeadCommandValidator : AbstractValidator<AddLeadCommand>
{
    public AddLeadCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(x => x.FullName).NotEmpty().WithMessage("Full name is required.");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");
        RuleFor(x => x.Suburb).NotEmpty().WithMessage("Suburb is required.");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}

using Application.Model;
using FluentValidation;

namespace Application.Validators;

public class ItemValidator : AbstractValidator<Item>
{
    public ItemValidator()
    {
        RuleFor(i => i.Name).NotEmpty();
        RuleFor(i => i.ExpirationDate).NotEmpty();
        RuleFor(i => i.Type).NotEmpty();
    }
}
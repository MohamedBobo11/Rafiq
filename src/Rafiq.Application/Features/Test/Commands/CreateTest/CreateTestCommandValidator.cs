using FluentValidation;

namespace Rafiq.Application.Features.Test.Commands.CreateTest;

public sealed class CreateTestCommandValidator : AbstractValidator<CreateTestCommand>
{
    public CreateTestCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.");

        RuleFor(x => x.State)
            .IsInEnum()
            .WithMessage("Invalid test state.");
    }
}
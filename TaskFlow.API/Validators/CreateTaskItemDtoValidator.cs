using FluentValidation;
using TaskFlow.API.DTOs;

namespace TaskFlow.API.Validators
{
    public class CreateTaskItemDtoValidator : AbstractValidator<CreateTaskItemDto>
    {
        public CreateTaskItemDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Max 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Max 500 characters.");
        }
    }
}

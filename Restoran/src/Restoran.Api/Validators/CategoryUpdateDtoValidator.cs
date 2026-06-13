using FluentValidation;
using Restaurant.Api.Dtos;

namespace Restaurant.Api.Validators
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategoriya nomi bo'sh bo'lishi mumkin emas.")
                .MaximumLength(50).WithMessage("Kategoriya nomi ko'pi bilan 50 ta belgi bo'lishi kerak.");
        }
    }
}
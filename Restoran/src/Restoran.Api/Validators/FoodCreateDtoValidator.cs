using FluentValidation;
using Restaurant.Api.Dtos;

namespace Restaurant.Api.Validators
{
    public class FoodCreateDtoValidator : AbstractValidator<FoodCreateDto>
    {
        public FoodCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Taom nomi bo'sh bo'lishi mumkin emas.")
                .MaximumLength(100).WithMessage("Taom nomi ko'pi bilan 100 ta belgi bo'lishi kerak.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Taom narxi 0 dan katta bo'lishi shart.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Yaroqli Kategoriya Id sini kiriting.");
        }
    }
}
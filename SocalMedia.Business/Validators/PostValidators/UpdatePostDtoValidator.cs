using FluentValidation;
using SocalMedia.Business.Dtos.PostDtos;

namespace SocalMedia.Business.Validators.PostValidators
{
    public class UpdatePostDtoValidator : AbstractValidator<UpdatePostDto>
    {
        public UpdatePostDtoValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty()
                .WithMessage("PostId cannot be empty.");

            RuleFor(x => x.Text)
                .MaximumLength(500)
                .WithMessage("Text can be a maximum of 500 characters.");


        }
    }
}

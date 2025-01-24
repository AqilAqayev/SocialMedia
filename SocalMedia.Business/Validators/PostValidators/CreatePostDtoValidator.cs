using FluentValidation;

namespace SocalMedia.Business.Validators.PostValidators;

public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
{
    public CreatePostDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId cannot be empty.");

        RuleFor(x => x.Text)
            .MaximumLength(500)
            .WithMessage("Text can be a maximum of 500 characters.");


    }
}

using FluentValidation;
using SocalMedia.Business.Dtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Validators.CommentValidators;

public class CommentDtoValidator : AbstractValidator<CommentDto>
{
    public CommentDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId cannot be empty.");

        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("UserName cannot be empty.");

        RuleFor(x => x.PostId)
            .GreaterThan(0)
            .WithMessage("PostId must be greater than zero.");

        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Comment text cannot be empty.")
            .MaximumLength(50000)
            .WithMessage("Comment text cannot exceed 500 characters.");

        RuleForEach(x => x.Children)
            .SetValidator(new CommentDtoValidator());
    }
}

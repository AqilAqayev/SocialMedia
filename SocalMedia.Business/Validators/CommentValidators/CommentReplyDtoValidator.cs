using FluentValidation;
using SocalMedia.Business.Dtos.CommentDtos;

namespace SocalMedia.Business.Validators.CommentValidators;

public class CommentReplyDtoValidator : AbstractValidator<CommentReplyDto>
{
    public CommentReplyDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Reply text cannot be empty.")
            .MaximumLength(500)
            .WithMessage("Reply text cannot exceed 500 characters.");

        RuleFor(x => x.ParentId)
            .GreaterThan(0)
            .WithMessage("ParentId must be greater than zero.");

        RuleFor(x => x.PostId)
            .GreaterThan(0)
            .WithMessage("PostId must be greater than zero.");
    }
}

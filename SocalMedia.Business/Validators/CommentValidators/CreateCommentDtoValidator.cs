using FluentValidation;
using SocalMedia.Business.Dtos.CommentDtos;

namespace SocalMedia.Business.Validators.CommentValidators;

public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
{
    public CreateCommentDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Comment text cannot be empty.")
            .MaximumLength(500)
            .WithMessage("Comment text cannot exceed 500 characters.");

        RuleFor(x => x.PostId)
            .GreaterThan(0)
            .WithMessage("PostId must be greater than zero.");
    }
}

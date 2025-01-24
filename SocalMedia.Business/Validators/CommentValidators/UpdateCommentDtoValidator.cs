using FluentValidation;
using SocalMedia.Business.Dtos.CommentDtos;

namespace SocalMedia.Business.Validators.CommentValidators;

public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
{
    public UpdateCommentDtoValidator()
    {
        RuleFor(x => x.CommentId)
            .GreaterThan(0)
            .WithMessage("CommentId must be greater than zero.");

        RuleFor(x => x.Text)
            .MaximumLength(500)
            .WithMessage("Updated comment text cannot exceed 500 characters.");
    }
}
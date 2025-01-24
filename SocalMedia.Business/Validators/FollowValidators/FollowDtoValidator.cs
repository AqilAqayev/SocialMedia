using FluentValidation;
using SocalMedia.Business.Dtos.FollowDtos;

namespace SocalMedia.Business.Validators.FollowValidators;

public class FollowDtoValidator : AbstractValidator<FollowDto>
{
    public FollowDtoValidator()
    {
        RuleFor(x => x.FollowerId)
            .NotEmpty()
            .WithMessage("FollowerId cannot be empty.");

        RuleFor(x => x.FollowingId)
            .NotEmpty()
            .WithMessage("FollowingId cannot be empty.");
    }
}

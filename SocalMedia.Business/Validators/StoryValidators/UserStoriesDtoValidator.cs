using FluentValidation;
using SocalMedia.Business.Dtos.StoryDtos;

namespace SocalMedia.Business.Validators.StoryValidators;

public class UserStoriesDtoValidator : AbstractValidator<UserStoriesDto>
{
    public UserStoriesDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId cannot be empty.");

        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("UserName cannot be empty.");

        RuleFor(x => x.ProfilePhotoUrl)
            .NotEmpty()
            .WithMessage("ProfilePhotoUrl cannot be empty.");

        RuleForEach(x => x.Stories)
            .SetValidator(new StoryDtoValidator());
    }
}
using FluentValidation;
using SocalMedia.Business.Dtos.StoryDtos;

namespace SocalMedia.Business.Validators.StoryValidators;

public class StoryDtoValidator : AbstractValidator<StoryDto>
{
    public StoryDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId cannot be empty.");

        RuleFor(x => x.StoryImages)
            .NotNull()
            .WithMessage("StoryImages cannot be null.");

        RuleFor(x => x.StoryVideos)
            .NotNull()
            .WithMessage("StoryVideos cannot be null.");
    }
}

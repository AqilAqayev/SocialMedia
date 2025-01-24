using FluentValidation;
using SocalMedia.Business.Dtos.StoryDtos;

namespace SocalMedia.Business.Validators.StoryValidators;

public class UpdateStoryDtoValidator : AbstractValidator<UpdateStoryDto>
{
    public UpdateStoryDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId cannot be empty.");
    }
}

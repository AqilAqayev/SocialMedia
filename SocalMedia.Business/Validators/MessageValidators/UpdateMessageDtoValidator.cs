using FluentValidation;
using SocalMedia.Business.Dtos.MessageDtos;

namespace SocalMedia.Business.Validators.MessageValidators;

public class UpdateMessageDtoValidator : AbstractValidator<UpdateMessageDto>
{
    public UpdateMessageDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Updated message text cannot be empty.")
            .MaximumLength(10000000)
            .WithMessage("Updated message text cannot exceed 10000000 characters.");
    }
}
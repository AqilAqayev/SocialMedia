using FluentValidation;
using SocalMedia.Business.Dtos.MessageDtos;

namespace SocalMedia.Business.Validators.MessageValidators;

public class CreateMessageDtoValidator : AbstractValidator<CreateMessageDto>
{
    public CreateMessageDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Message text cannot be empty.")
            .MaximumLength(1000)
            .WithMessage("Message text cannot exceed 1000 characters.");

        RuleFor(x => x.FromUserId)
            .NotEmpty()
            .WithMessage("FromUserId cannot be empty.");

        RuleFor(x => x.ToUserId)
            .NotEmpty()
            .WithMessage("ToUserId cannot be empty.");
    }
}

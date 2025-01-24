using FluentValidation;
using SocalMedia.Business.Dtos.MessageDtos;

namespace SocalMedia.Business.Validators.MessageValidators;

public class SendMessageDtoValidator : AbstractValidator<SendMessageDto>
{
    public SendMessageDtoValidator()
    {
        RuleFor(x => x.ChatId)
            .GreaterThan(0)
            .WithMessage("ChatId must be greater than zero.");

        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Message text cannot be empty.")
            .MaximumLength(10000000)
            .WithMessage("Message text cannot exceed 10000000 characters.");
    }
}

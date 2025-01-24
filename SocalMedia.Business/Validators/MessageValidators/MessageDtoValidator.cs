using FluentValidation;
using SocalMedia.Business.Dtos.MessageDtos;

namespace SocalMedia.Business.Validators.MessageValidators;

public class MessageDtoValidator : AbstractValidator<MessageDto>
{
    public MessageDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Message text cannot be empty.")
            .MaximumLength(10000000)
            .WithMessage("Message text cannot exceed 10000000 characters.");

        RuleFor(x => x.FromUserId)
            .NotEmpty()
            .WithMessage("FromUserId cannot be empty.")
            .When(x => !string.IsNullOrEmpty(x.FromUserId));

        RuleFor(x => x.SenderId)
            .NotEmpty()
            .WithMessage("SenderId cannot be empty.")
            .When(x => !string.IsNullOrEmpty(x.SenderId));
    }
}

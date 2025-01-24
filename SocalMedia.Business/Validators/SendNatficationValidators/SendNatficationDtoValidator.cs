using FluentValidation;
using SocalMedia.Business.Dtos.SendNatficationDtos;

namespace SocalMedia.Business.Validators.SendNatficationValidators;

public class SendNatficationDtoValidator : AbstractValidator<SendNatficationDto>
{
    public SendNatficationDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId cannot be empty.");


        RuleFor(x => x.SenderId)
            .NotEmpty()
            .WithMessage("UserId cannot be empty.");
        RuleFor(x => x.SenderName)
                 .NotEmpty()
                 .WithMessage("SenderName cannot be empty.");


    }
}

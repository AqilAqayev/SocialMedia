using FluentValidation;
using SocalMedia.Business.Dtos.SendNatficationDtos;

namespace SocalMedia.Business.Validators.SendNatficationValidators;

public class UpdateSendNatficationDtoValidator : AbstractValidator<UpdateSendNatficationDto>
{
    public UpdateSendNatficationDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId cannot be empty.");


        RuleFor(x => x.SenderId)
            .NotEmpty()
            .WithMessage("UserId cannot be empty.");

    }
}
using SocalMedia.Business.Dtos.SendNatficationDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface ISendNatficationService : ICrudService<SendNatfication, CreateSendNatficationDto, UpdateSendNatficationDto, SendNatficationDto>
{
}
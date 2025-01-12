using AutoMapper;
using SocalMedia.Business.Dtos.SendNatficationDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class SendNatficationService : CrudService<SendNatfication, CreateSendNatficationDto, UpdateSendNatficationDto, SendNatficationDto>, ISendNatficationService
{
    public SendNatficationService(ISendNatficationRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
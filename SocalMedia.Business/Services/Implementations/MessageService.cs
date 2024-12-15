using AutoMapper;
using SocalMedia.Business.Dtos.MessageDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class MessageService : CrudService<Message, CreateMessageDto, UpdateMessageDto, MessageDto>, IMessageService
{
    public MessageService(IMessageRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

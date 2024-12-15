using SocalMedia.Business.Dtos.MessageDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface IMessageService : ICrudService<Message, CreateMessageDto, UpdateMessageDto, MessageDto>
{
}

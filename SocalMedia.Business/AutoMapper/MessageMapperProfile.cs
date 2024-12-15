using AutoMapper;
using SocalMedia.Business.Dtos.MessageDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class MessageMapperProfile : Profile
{
    public MessageMapperProfile()
    {
        CreateMap<Message,MessageDto>().ReverseMap();
        CreateMap<Message,CreateMessageDto>().ReverseMap();
        CreateMap<Message,UpdateMessageDto>().ReverseMap();
    }
}

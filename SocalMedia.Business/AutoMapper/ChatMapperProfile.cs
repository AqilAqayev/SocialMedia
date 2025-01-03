using AutoMapper;
using SocalMedia.Business.Dtos.ChatDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class ChatMapperProfile : Profile
{
    public ChatMapperProfile()
    {
        CreateMap<Chat, ChatDto>().ReverseMap();
        CreateMap<Chat, CreateChatDto>().ReverseMap();
        CreateMap<Chat, UpdateChatDto>().ReverseMap();
    }
}
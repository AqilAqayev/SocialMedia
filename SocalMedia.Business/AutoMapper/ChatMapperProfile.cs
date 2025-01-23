using AutoMapper;
using SocalMedia.Business.Dtos.ChatDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class ChatMapperProfile : Profile
{
    public ChatMapperProfile()
    {
        CreateMap<Chat, ChatDto>()
        .ForMember(dest=>dest.Messages, opt => opt.MapFrom(src => src.Messages))
        .ForMember(destinationMember => destinationMember.ProfileUrl, options => options.MapFrom(source => source.User.ProfilePhotoUrl))
        .ForMember(destinationMember => destinationMember.Name, options => options.MapFrom(source => source.User.UserName))
        .ReverseMap();


        CreateMap<Chat, CreateChatDto>().ReverseMap();
        CreateMap<Chat, UpdateChatDto>().ReverseMap();
    }
}
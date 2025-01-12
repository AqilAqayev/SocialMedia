using AutoMapper;
using SocalMedia.Business.Dtos.SendNatficationDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class SendNatficationMapperProfile : Profile
{
    public SendNatficationMapperProfile()
    {
        CreateMap<SendNatfication, CreateSendNatficationDto>().ReverseMap();
        CreateMap<SendNatfication, UpdateSendNatficationDto>().ReverseMap();
        CreateMap<SendNatfication, SendNatficationDto>().ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.ProfileUrl, opt => opt.MapFrom(src => src.User.ProfilePhotoUrl))
            .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.User.Id))
            .ReverseMap();
    }
}

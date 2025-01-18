using AutoMapper;
using SocalMedia.Business.Dtos;
using SocalMedia.Business.Dtos.CommentDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class CommentMapperProfile : Profile
{
    public CommentMapperProfile()
    {
        CreateMap<Comment, CreateCommentDto>().ReverseMap();
        CreateMap<Comment, UpdateCommentDto>().ReverseMap();

        CreateMap<Comment, CommentDto>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
               .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
               .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Children))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
               .ForMember(dest => dest.ProfilePhotoUrl, opt => opt.MapFrom(src => src.User.ProfilePhotoUrl))
               .ReverseMap();

    }
}

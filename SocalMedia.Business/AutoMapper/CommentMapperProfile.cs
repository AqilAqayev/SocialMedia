using AutoMapper;
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
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName))
               .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text)) 
               .ReverseMap();
    }
}

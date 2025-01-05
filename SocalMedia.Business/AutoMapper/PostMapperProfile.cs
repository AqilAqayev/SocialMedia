using AutoMapper;
using SocalMedia.Business.Dtos.PostDtos;
using SocalMedia.Business.Dtos.PostImageDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class PostMapperProfile : Profile
{
    public PostMapperProfile()
    {

        CreateMap<Post, PostDto>()
           .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.PostImages.Select(i => i.ImageUrl).ToList()))
           .ForMember(dest => dest.VideoUrls, opt => opt.MapFrom(src => src.PostVideos.Select(v => v.VideoUrl).ToList()))
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName)) // Map UserName from AppUser
           .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments)) // Correctly map Comments
           .ReverseMap();

    }
}

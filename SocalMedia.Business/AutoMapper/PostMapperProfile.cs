using AutoMapper;
using SocalMedia.Business.Dtos;
using SocalMedia.Business.Dtos.CommentDtos;
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
              .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
              .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments.Where(c => c.ParentId == null)))
              .ForMember(dest=> dest.CommentCount, opt => opt.MapFrom(src => src.CommentCount))
              .ForMember(dest=> dest.UserName, opt=> opt.MapFrom(src=>src.User.UserName))
              .ForMember(dext => dext.ProfilePhotoUrl, opt => opt.MapFrom(src => src.User.ProfilePhotoUrl))
              .ReverseMap();

        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Children)) 
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember( dest => dest.ProfilePhotoUrl, opt => opt.MapFrom(src => src.User.ProfilePhotoUrl))
            .ReverseMap();

    }
}

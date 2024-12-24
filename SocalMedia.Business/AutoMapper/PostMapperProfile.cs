using AutoMapper;
using SocalMedia.Business.Dtos.PostDtos;
using SocalMedia.Business.Dtos.PostImageDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class PostMapperProfile : Profile
{
    public PostMapperProfile()
    {
        
        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();
        CreateMap<Post,PostDto>().ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.PostImages.Select(img => new PostImageDto
        {
            Id = img.Id,
            ImageUrl = img.ImageUrl
        }).ToList())).ReverseMap();
    }
}

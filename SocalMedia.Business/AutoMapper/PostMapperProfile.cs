using AutoMapper;
using SocalMedia.Business.Dtos.PostDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class PostMapperProfile : Profile
{
    public PostMapperProfile()
    {
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();
    }
}

using AutoMapper;
using SocalMedia.Business.Dtos.PostImageDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class PostImangeMapperProfile : Profile
{
    public PostImangeMapperProfile()
    {
        CreateMap<PostImage, PostImageDto>().ReverseMap();
        CreateMap<PostImage, CreatePostImageDto>().ReverseMap();
        CreateMap<PostImage, UpdatePostImageDto>().ReverseMap();
    }
}

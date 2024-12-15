using AutoMapper;
using SocalMedia.Business.Dtos.PostVideoDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class PostVideoMapperProfile : Profile
{
    public PostVideoMapperProfile()
    {
        CreateMap<PostVideo, PostVideoDto>().ReverseMap();
        CreateMap<PostVideo, CreatePostVideoDto>().ReverseMap();
        CreateMap<PostVideo, UpdatePostVideoDto>().ReverseMap();
    }
}
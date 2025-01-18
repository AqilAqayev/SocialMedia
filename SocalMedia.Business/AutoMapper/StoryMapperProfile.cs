using AutoMapper;
using SocalMedia.Business.Dtos.StoryDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class StoryMapperProfile : Profile
{
    public StoryMapperProfile()
    {
        CreateMap<Story, CreateStoryDto>().ReverseMap();
        CreateMap<Story, UpdateStoryDto>().ReverseMap();
        CreateMap<Story, StoryDto>()
             .ForMember(dest => dest.StoryImages, opt => opt.MapFrom(src => src.StoryImages.Select(i => i.ImageUrl).ToList()))
             .ForMember(dest => dest.StoryVideos, opt => opt.MapFrom(src => src.StoryVideos.Select(v => v.VideoUrl).ToList()))
             .ReverseMap();

    }
}

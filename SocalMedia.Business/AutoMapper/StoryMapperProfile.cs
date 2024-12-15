using AutoMapper;
using SocalMedia.Business.Dtos.StoryDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class StoryMapperProfile : Profile
{
    public StoryMapperProfile()
    {
        CreateMap<Story, StoryDto>().ReverseMap();
        CreateMap<Story, CreateStoryDto>().ReverseMap();
        CreateMap<Story, UpdateStoryDto>().ReverseMap();
    }
}

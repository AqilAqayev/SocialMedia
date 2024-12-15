using AutoMapper;
using SocalMedia.Business.Dtos.StoryVideoDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class StoryVideoMapperProfile : Profile
{
    public StoryVideoMapperProfile()
    {
        CreateMap<StoryVideo, StoryVideoDto>().ReverseMap();
        CreateMap<StoryVideo, CreateStoryVideoDto>().ReverseMap();
        CreateMap<StoryVideo, UpdateStoryVideoDto>().ReverseMap();
      
    }
}

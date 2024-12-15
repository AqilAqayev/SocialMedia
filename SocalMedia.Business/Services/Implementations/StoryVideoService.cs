using AutoMapper;
using SocalMedia.Business.Dtos.StoryVideoDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class StoryVideoService : CrudService<StoryVideo, CreateStoryVideoDto, UpdateStoryVideoDto, StoryVideoDto>, IStoryVideoService
{
    public StoryVideoService(IStoryVideoRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
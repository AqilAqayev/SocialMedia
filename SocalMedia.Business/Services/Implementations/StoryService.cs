using AutoMapper;
using SocalMedia.Business.Dtos.StoryDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class StoryService : CrudService<Story, CreateStoryDto, UpdateStoryDto, StoryDto>, IStoryService
{
    public StoryService(IStoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

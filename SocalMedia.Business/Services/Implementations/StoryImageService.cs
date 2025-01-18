using AutoMapper;
using SocalMedia.Business.Dtos.StoryImageDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class StoryImageService : CrudService<StoryImage, CreateStoryImageDto, UpdateStoryImageDto, StoryImageDto>, IStoryImageService
{
    public StoryImageService(IStoryImageRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
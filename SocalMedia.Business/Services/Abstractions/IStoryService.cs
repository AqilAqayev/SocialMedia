using SocalMedia.Business.Dtos.StoryDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface IStoryService : ICrudService<Story, CreateStoryDto, UpdateStoryDto, StoryDto>
{
}

using SocalMedia.Business.Dtos.StoryImageDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface IStoryImageService : ICrudService<StoryImage, CreateStoryImageDto, UpdateStoryImageDto, StoryImageDto>
{
}
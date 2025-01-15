using Microsoft.Extensions.Hosting;
using SocalMedia.Business.Dtos.StoryVideoDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface IStoryVideoService : ICrudService<StoryVideo, CreateStoryVideoDto, UpdateStoryVideoDto, StoryVideoDto>
{
}
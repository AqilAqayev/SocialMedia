using SocalMedia.Business.Dtos.PostVideoDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface IPostVideoService : ICrudService<PostVideo, CreatePostVideoDto, UpdatePostVideoDto, PostVideoDto>
{
}

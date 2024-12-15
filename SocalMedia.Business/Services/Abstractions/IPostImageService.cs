using SocalMedia.Business.Dtos.PostImageDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface IPostImageService : ICrudService<PostImage, CreatePostImageDto, UpdatePostImageDto, PostImageDto>
{
}

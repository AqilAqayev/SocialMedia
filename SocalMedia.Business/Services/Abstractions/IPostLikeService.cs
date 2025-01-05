using SocalMedia.Business.Dtos.PostLikeDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface IPostLikeService : ICrudService<PostLike, CreatePostLikeDto, UpdatePostLikeDto, PostLikeDto>
{
}

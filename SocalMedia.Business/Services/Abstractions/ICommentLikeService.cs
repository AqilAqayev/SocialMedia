using SocalMedia.Business.Dtos.CommentLikeDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface ICommentLikeService : ICrudService<CommentLike, CreateCommentLikeDto, UpdateCommentLikeDto, CommentLikeDto>
{
}

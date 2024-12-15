using AutoMapper;
using SocalMedia.Business.Dtos.CommentLikeDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class CommentLikeService : CrudService<CommentLike, CreateCommentLikeDto, UpdateCommentLikeDto, CommentLikeDto>, ICommentLikeService
{
    public CommentLikeService(ICommentLikeRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}


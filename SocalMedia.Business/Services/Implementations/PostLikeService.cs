using AutoMapper;
using SocalMedia.Business.Dtos.PostLikeDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class PostLikeService : CrudService<PostLike, CreatePostLikeDto, UpdatePostLikeDto, PostLikeDto>, IPostLikeService
{
    public PostLikeService(IPostLikeRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
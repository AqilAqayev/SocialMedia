using AutoMapper;
using SocalMedia.Business.Dtos.PostDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Abstraction.Generic;

namespace SocalMedia.Business.Services.Implementations;

public class PostService : CrudService<Post, CreatePostDto, UpdatePostDto, PostDto>, IPostService
{
    public PostService(IPostRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

using AutoMapper;
using SocalMedia.Business.Dtos.PostImageDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Abstraction.Generic;

namespace SocalMedia.Business.Services.Implementations;

public class PostImageService : CrudService<PostImage, CreatePostImageDto, UpdatePostImageDto, PostImageDto>, IPostImageService
{
    public PostImageService(IPostImageRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}


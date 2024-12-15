using AutoMapper;
using SocalMedia.Business.Dtos.PostVideoDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Abstraction.Generic;

namespace SocalMedia.Business.Services.Implementations;

public class PostVideoService : CrudService<PostVideo, CreatePostVideoDto, UpdatePostVideoDto, PostVideoDto>, IPostVideoService
{
    public PostVideoService(IPostVideoRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}


using AutoMapper;
using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Dtos.PostDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class CommentService : CrudService<Comment, CreateCommentDto, UpdateCommentDto, CommentDto>, ICommentService
{
    public CommentService(ICommentRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

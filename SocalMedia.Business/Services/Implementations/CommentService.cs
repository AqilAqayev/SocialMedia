using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocalMedia.Business.Dtos;
using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class CommentService : CrudService<Comment, CreateCommentDto, UpdateCommentDto, CommentDto>, ICommentService
{
    private readonly ICommentRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CommentService(ICommentRepository repository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(repository, mapper)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> AddCommentAsync(CreateCommentDto dto)
    {
        //string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ////var post = await _repository.GetAsync(dto.PostId, p => p.Post, p => p.Post.User);
        //if (post == null) return false;

        //var comment = new Comment
        //{
        //    Text = dto.Text,
        //    Rating = dto.Rating,
        //    PostId = dto.PostId,
        //    AppUserId = userId,
        //    CreatedTime = DateTime.UtcNow
        //};

        //await _repository.CreateAsync(comment);
        //post.CommentCount++;

        //await _repository.SaveChangesAsync(); 
        return true;
    }

    public Task<bool> ReplyToCommentAsync(CommentReplyDto dto)
    {
        throw new NotImplementedException();
    }
}

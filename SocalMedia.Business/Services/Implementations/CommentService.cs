using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocalMedia.Business.Dtos;
using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;
using static System.Net.WebRequestMethods;
using System.Security.Claims;
using SocalMedia.Business.Exceptions;

namespace SocalMedia.Business.Services.Implementations;

public class CommentService : CrudService<Comment, CreateCommentDto, UpdateCommentDto, CommentDto>, ICommentService
{
    private readonly ICommentRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public CommentService(ICommentRepository repository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IPostRepository postRepository) : base(repository, mapper)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
        _postRepository = postRepository;
    }



    public async Task<bool> DeleteCommentAsync(int commentId, int postId)
    {
        var post = await _postRepository.GetAsync(postId);
        if (post == null)
        {
            throw new NotFoundException("Comment not found");

        }
        string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
        if (userId is null)
        {
            throw new NotFoundException();
        }
        var cmm = await _repository.GetAsync(commentId);
        if (cmm == null)
        {
            throw new NotFoundException("Comment not found");
        }

        if (cmm.AppUserId == userId)
        {
            post.CommentCount--;
            _postRepository.Update(post);
            await _postRepository.SaveChangesAsync();
            await _repository.Delete(cmm);
        }

        if (post.UserId == userId)
        {
            post.CommentCount--;
            _postRepository.Update(post);
            await _postRepository.SaveChangesAsync();
            await _repository.Delete(cmm);
        }

        return true;
    }
}

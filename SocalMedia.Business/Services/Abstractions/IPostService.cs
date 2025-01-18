using SocalMedia.Business.Dtos;
using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Dtos.PostDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;
using System.Linq.Expressions;

namespace SocalMedia.Business.Services.Abstractions;

public interface IPostService : ICrudService<Post, CreatePostDto, UpdatePostDto, PostDto>
{
    Task<int> CreatePostAsync(CreatePostDto createPostDto);
    Task<List<PostDto>> GetAllPostAsync(Expression<Func<Post, bool>>? predicate);
    Task<int> GetPostCountAsync();
    Task<bool> LikePostAsync(int postId);
    Task<int> GetPostLikeCountAsync(int postId);

    Task<CommentDto> AddCommentAsync(CreateCommentDto dto, string userId);
    Task<CommentDto> AddReplyAsync(CommentReplyDto dto, string userId);
}

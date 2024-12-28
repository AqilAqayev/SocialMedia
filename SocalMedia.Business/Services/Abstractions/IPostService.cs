using SocalMedia.Business.Dtos.PostDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;
using System.Linq.Expressions;

namespace SocalMedia.Business.Services.Abstractions;

public interface IPostService : ICrudService<Post, CreatePostDto, UpdatePostDto, PostDto>
{
    Task<int> CreatePostAsync(CreatePostDto createPostDto);
    Task<List<Post>> GetAllAsync(Expression<Func<Post, bool>> predicate);
}

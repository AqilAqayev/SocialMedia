using SocalMedia.Business.Dtos.PostDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface IPostService : ICrudService<Post, CreatePostDto, UpdatePostDto, PostDto>
{
    Task<int> CreatePostAsync(CreatePostDto createPostDto);
    List<PostDto> GetAllPosts();
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocalMedia.Business.Dtos.PostDtos;
using SocalMedia.Business.Dtos.PostImageDtos;
using SocalMedia.Business.Dtos.PostVideoDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Abstraction.Generic;
using System.Security.Claims;

namespace SocalMedia.Business.Services.Implementations;

public class PostService : CrudService<Post, CreatePostDto, UpdatePostDto, PostDto>, IPostService
{
    private readonly IRepository<Post> _postRepository;
    private readonly IRepository<PostImage> _postImageRepository;
    private readonly IRepository<PostVideo> _postVideoRepository;
    private readonly ICloudinaryManager _cloudinaryManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PostService(IPostRepository repository, IMapper mapper, IRepository<Post> postRepository, IRepository<PostImage> postImageRepository, IRepository<PostVideo> postVideoRepository, ICloudinaryManager cloudinaryManager, IHttpContextAccessor httpContextAccessor) : base(repository, mapper)
    {
        _postRepository = postRepository;
        _postImageRepository = postImageRepository;
        _postVideoRepository = postVideoRepository;
        _cloudinaryManager = cloudinaryManager;
        _httpContextAccessor = httpContextAccessor;
    }
    public List<PostDto> GetAllPosts()
    {
       
        return _postRepository.GetAll().Select(p => new PostDto
        {
            UserId = p.UserId,
           
            Text = p.Text,
            CreatedTime = p.CreatedTime,
            //ImageUrls = p.PostImages.Select(i => i.ImageUrl).ToList(),
            //VideoUrls = p.PostVideos.Select(v => v.VideoUrl).ToList(),
            Comments = p.Comments.Select(c => c.Text).ToList(),
        }).ToList();
    }

    public async Task<int> CreatePostAsync(CreatePostDto createPostDto)
    {
        string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

        var post = new Post
        {
            UserId = userId,
            Text = createPostDto.Text ?? "",
            CreatedTime = DateTime.UtcNow
        };

        await _postRepository.CreateAsync(post);
        await _postRepository.SaveChangesAsync();

        foreach (var image in createPostDto.ImageUrls)
        {
            string imageUrl = await _cloudinaryManager.FileCreateAsync(image);
            var imageEntity = new PostImage
            {
                PostId = post.Id,
                ImageUrl = imageUrl
            };
            await _postImageRepository.CreateAsync(imageEntity);
        }

        foreach (var video in createPostDto.VideoUrls)
        {
            string videoUrl = await _cloudinaryManager.FileCreateAsync(video);
            var videoEntity = new PostVideo
            {
                PostId = post.Id,
                VideoUrl = videoUrl
            };
            await _postVideoRepository.CreateAsync(videoEntity);
        }

        await _postImageRepository.SaveChangesAsync();
        await _postVideoRepository.SaveChangesAsync();

        return post.Id;
    }
}

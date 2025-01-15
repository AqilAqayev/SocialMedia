using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Dtos.PostDtos;
using SocalMedia.Business.Dtos.PostImageDtos;
using SocalMedia.Business.Dtos.PostVideoDtos;
using SocalMedia.Business.Exceptions;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Abstraction.Generic;
using System.Linq.Expressions;
using System.Security.Claims;

namespace SocalMedia.Business.Services.Implementations;

public class PostService : CrudService<Post, CreatePostDto, UpdatePostDto, PostDto>, IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IRepository<PostImage> _postImageRepository;
    private readonly IRepository<PostVideo> _postVideoRepository;
    private readonly ICloudinaryManager _cloudinaryManager;
    private readonly IPostLikeRepository _postLikeRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;
    private readonly ICommentRepository _commentRepository;

    public PostService(IPostRepository repository, IMapper mapper, IPostRepository postRepository, IRepository<PostImage> postImageRepository, IRepository<PostVideo> postVideoRepository, ICloudinaryManager cloudinaryManager, IHttpContextAccessor httpContextAccessor, AppDbContext appDbContext, IPostLikeRepository postLikeRepository, ICommentRepository commentRepository) : base(repository, mapper)
    {
        _postRepository = postRepository;
        _postImageRepository = postImageRepository;
        _postVideoRepository = postVideoRepository;
        _cloudinaryManager = cloudinaryManager;
        _httpContextAccessor = httpContextAccessor;
        _appDbContext = appDbContext;
        _mapper = mapper;
        _postLikeRepository = postLikeRepository;
        _commentRepository = commentRepository;
    }
    public async Task<List<PostDto>> GetAllPostAsync(Expression<Func<Post, bool>>? predicate)
    {
        var entity = await _appDbContext.Posts
        .Include(p => p.PostImages)
        .Include(p => p.PostVideos)
        .Include(p => p.Comments).ThenInclude(c => c.User)
        .Include(p=>p.User)
        .Where(predicate)
        .ToListAsync();

        var dto = _mapper.Map<List<PostDto>>(entity);

        return dto;
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
            string videoUrl = await _cloudinaryManager.VideoUploadAsync(video);
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

    public async Task<bool> LikePostAsync(int postId)
    {
        string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        if (userId == null)
            return false;
        var post = await _postRepository.GetAsync(postId,include:x=>x.Include(x=>x.PostLikes));

        if (post == null)
            return false;

        var existingLike = post.PostLikes.FirstOrDefault(like => like.UserId == userId);

        if (existingLike != null)
        {
            _postLikeRepository.Delete(existingLike);
            post.Count--;

            _postRepository.Update(post);

            await _postLikeRepository.SaveChangesAsync();
            await _postRepository.SaveChangesAsync();
            return true;
        }

        var postLike = new PostLike
        {
            PostId = postId,
            UserId = userId
        };

        await _postLikeRepository.CreateAsync(postLike);
        await _postLikeRepository.SaveChangesAsync();

        post.Count++;

        _postRepository.Update(post);
        await _postRepository.SaveChangesAsync();
        

      

        return true;
    }
    public async Task<int> GetPostCountAsync()
    {
        return await Task.Run(() => _postRepository.GetAll().Count());
    }

    public async Task<int> GetPostLikeCountAsync(int postId)
    {
        var post = await _postRepository.GetAsync(p => p.Id == postId, include: query => query.Include(p => p.PostLikes));
        if (post == null)
        {
            throw new NotFoundException("Post not found");
        }
        return post.PostLikes.Count;
    }

    public async Task AddCommentAsync(CreateCommentDto dto, string userId)
    {
        var post = await _postRepository.GetPostWithCommentsAsync(dto.PostId);
        if (post == null) throw new NotFoundException("Post not found");

        Comment comment = new()
        {
            Text = dto.Text,
            AppUserId = userId,
            PostId = dto.PostId,
            CreatedTime = DateTime.UtcNow
        };

        post.Comments.Add(comment);
        post.CommentCount++;

        await _commentRepository.CreateAsync(comment);

        await _postRepository.SaveChangesAsync();
    }

    public async Task AddReplyAsync(CommentReplyDto dto, string userId)
    {
        var post = await _postRepository.GetPostWithCommentsAsync(dto.PostId);
        if (post == null) throw new NotFoundException("Post not found");

        var parentComment = await _commentRepository.GetAsync(c => c.Id == dto.ParentId && c.ParentId == null);
        if (parentComment == null) throw new NotFoundException("Parent comment not found");

        Comment replyComment = new()
        {
            Text = dto.Text,
            ParentId = dto.ParentId,
            PostId = dto.PostId,
            AppUserId = userId,
            CreatedTime = DateTime.UtcNow
        };

        await _commentRepository.CreateAsync(replyComment);
        post.CommentCount++;

        await _postRepository.SaveChangesAsync();
    }


}

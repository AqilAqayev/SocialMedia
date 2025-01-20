using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocalMedia.Business.Dtos.StoryDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;


using System.Security.Claims;

namespace SocalMedia.Business.Services.Implementations;

public class StoryService : CrudService<Story, CreateStoryDto, UpdateStoryDto, StoryDto>, IStoryService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IStoryRepository _storyRepository;
    private readonly IStoryVideoRepository _storyVideoRepository;
    private readonly IStoryImageRepository _storyImageRepository;
    private readonly ICloudinaryManager _cloudinaryManager;
    private readonly IMapper _mapper;
    public StoryService(IStoryRepository repository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IStoryRepository storyRepository, IStoryVideoRepository storyVideoRepository, ICloudinaryManager cloudinaryManager, IStoryImageRepository storyImageRepository) : base(repository, mapper)
    {
        _httpContextAccessor = httpContextAccessor;
        _storyRepository = storyRepository;
        _storyVideoRepository = storyVideoRepository;
        _cloudinaryManager = cloudinaryManager;
        _storyImageRepository = storyImageRepository;
        _mapper = mapper;
    }

    public async Task<int> CreatStoryAsync(CreateStoryDto createStoryDto)
    {
        string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

        var story = new Story
        {
            UserId = userId,
            CreatedTime = DateTime.UtcNow
        };

        await _storyRepository.CreateAsync(story);
        await _storyRepository.SaveChangesAsync();

        foreach (var image in createStoryDto.ImagesUrls)
        {
            string imageUrl = await _cloudinaryManager.FileCreateAsync(image);
            var imageEntity = new StoryImage
            {
                StoryId = story.Id,
                ImageUrl = imageUrl
            };

            await _storyImageRepository.CreateAsync(imageEntity);
        }
        await _storyImageRepository.SaveChangesAsync();


        foreach (var video in createStoryDto.VideoUrls)
        {
            string videoUrl = await _cloudinaryManager.VideoUploadAsync(video);
            var videoEntity = new StoryVideo
            {
                StoryId = story.Id,
                VideoUrl = videoUrl
            };
            await _storyVideoRepository.CreateAsync(videoEntity);
        }


        await _storyVideoRepository.SaveChangesAsync();

        return story.Id;
    }

    public async  Task<List<StoryDto>> GetAllActiveStoriesAsync()
    {
        var activeStories = await _storyRepository.GetAllActiveStoriesAsync();
        var dto = _mapper.Map<List<StoryDto>>(activeStories);
        return dto;
    }


    public async Task<List<UserStoriesDto>> GetAllUserStoriesAsync()
    {
        var activeStories = await _storyRepository.GetAllActiveStoriesAsync();

        if (activeStories == null || !activeStories.Any())
        {
            return new List<UserStoriesDto>();
        }

        var groupedStories = activeStories
            .GroupBy(s => s.UserId)
            .Select(group => new UserStoriesDto
            {
                UserId = group.Key,
                UserName = group.First().User?.UserName ?? "Unknown",
                ProfilePhotoUrl = group.First().User?.ProfilePhotoUrl ?? "",
                Stories = _mapper.Map<List<StoryDto>>(group.ToList())
            })
            .ToList();

        return groupedStories;
    }



}

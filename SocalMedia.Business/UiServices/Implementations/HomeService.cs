using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using SocalMedia.Business.Dtos.HomeDtos;
using SocalMedia.Business.Dtos.SearchDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;
using System.Security.Claims;

namespace SocalMedia.Business.UiServices.Implementations
{
    public class HomeService : IHomeService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IStoryService _storyService;


        public HomeService(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IPostService postService, ICommentService commentService, UserManager<AppUser> userManager, IStoryService storyService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _postService = postService;
            _commentService = commentService;
            _userManager = userManager;
            _storyService = storyService;
        }

        public async Task<HomeDto> GetHomeDto()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var posts = (await _postService.GetAllPostAsync(x => x.UserId != userId))
               .OrderByDescending(p => p.CreatedTime) 
               .ToList();
            var story =await _storyService.GetAllActiveStoriesAsync();
            var user = await _userManager.FindByIdAsync(userId);
            HomeDto homeDto = new HomeDto
            {
                Posts = posts,
                Stories= story

            };
            return homeDto;
        }

        public async Task<SearchUsersDto> SearchUsersAsync(string query)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            if (userId == null)
            {
                return new SearchUsersDto { SearchDtos = new List<SearchDto>() };
            }

            var queryes = await _userRepository.GetAllAsync(user =>
                (user.UserName!.Contains(query)) && 
                user.Id != userId); 

            var model = new SearchUsersDto
            {
                SearchDtos = queryes.Select(u => new SearchDto
                {
                    UserId = u.Id,
                    UserName = u.UserName!,
                    ProfileImage = u.ProfilePhotoUrl!

                }).ToList()
            };

            return model;
        }

        public async Task<HomeDto> GetPaginatedHomeDtoAsync(int page, int pageSize)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var posts = await _postService.GetAllPostAsync(x => x.UserId != userId);

            var paginatedPosts = posts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            HomeDto homeDto = new HomeDto
            {
                Posts = posts,

            };
            return homeDto;
        }

    }
}

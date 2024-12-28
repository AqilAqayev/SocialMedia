using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocalMedia.Business.Dtos.SearchDtos;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.DataAccess.Repositories.Abstraction;
using System.Security.Claims;

namespace SocalMedia.Business.UiServices.Implementations
{
    public class HomeService : IHomeService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeService(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<SearchUsersDto> SearchUsersAsync(string query)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            if (userId == null)
            {
                return new SearchUsersDto { SearchDtos = new List<SearchDto>() };
            }

            var queryes = await _userRepository.GetAllAsync(user =>
                (user.UserName!.Contains(query) || user.Email!.Contains(query)) && 
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
    }
}

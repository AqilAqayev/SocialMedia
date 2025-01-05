using SocalMedia.Business.Dtos.HomeDtos;
using SocalMedia.Business.Dtos.SearchDtos;

namespace SocalMedia.Business.UiServices.Abstractions;

public interface IHomeService
{
    Task <HomeDto> GetHomeDto();
    Task<SearchUsersDto> SearchUsersAsync(string query);
    Task<HomeDto> GetPaginatedHomeDtoAsync(int page, int pageSize);
}

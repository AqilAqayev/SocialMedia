using SocalMedia.Business.Dtos.SearchDtos;

namespace SocalMedia.Business.UiServices.Abstractions;

public interface IHomeService
{
    Task<SearchUsersDto> SearchUsersAsync(string query);
}

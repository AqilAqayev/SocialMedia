using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.SearchDtos;

public class SearchDto :IDto
{
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string ProfileImage { get; set; } = null!;
}

public class SearchUsersDto : IDto
{
   public List<SearchDto> SearchDtos { get; set; } =  new List<SearchDto>();
}

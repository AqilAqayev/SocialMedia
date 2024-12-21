
using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos;

public class ConnectionDto : IDto
{
    public string UserId { get; set; } = null!;
    public List<string> ConnectionIds { get; set; } = [];
}

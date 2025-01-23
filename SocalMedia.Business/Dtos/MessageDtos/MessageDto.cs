using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.MessageDtos;

public class MessageDto : IDto
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public string FromUserId { get; set; } = null!;
    public string ToUserId { get; set; } = null!;
    public DateTime CreatedTime { get; set; }
    public bool IsDelete { get; set; }
    public bool IsRead { get; set; }
}

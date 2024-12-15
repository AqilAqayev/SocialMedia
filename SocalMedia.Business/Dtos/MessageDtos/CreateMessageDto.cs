using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.MessageDtos;

public class CreateMessageDto : IDto
{
    public string Text { get; set; } = null!;
    public string FromUserId { get; set; } = null!;
    public string ToUserId { get; set; } = null!;
}

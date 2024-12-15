using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.MessageDtos;

public class UpdateMessageDto : IDto
{
    public string Text { get; set; } = null!;
}

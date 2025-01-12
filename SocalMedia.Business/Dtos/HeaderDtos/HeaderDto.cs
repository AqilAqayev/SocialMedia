using SocalMedia.Business.Dtos.ChatDtos;
using SocalMedia.Business.Dtos.Generic;
using SocalMedia.Business.Dtos.SendNatficationDtos;

namespace SocalMedia.Business.Dtos.HeaderDtos
{
    public class HeaderDto : IDto
    {
        public List<ChatDto> Chats { get; set; } = [];
        public string? Username { get; set; } 
        public string? ProfileUrl { get; set; }
        public string? UserId { get; set; }
        public List<SendNatficationDto> SendNatfication { get; set; } = []; 
    }
}

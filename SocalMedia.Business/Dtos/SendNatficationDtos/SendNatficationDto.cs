using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.SendNatficationDtos
{
    public class SendNatficationDto : IDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? SenderId { get; set; }
        public string? SenderName { get;set; }
        public string?  ProfileUrl { get; set; }
    }
}

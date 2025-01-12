using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.SendNatficationDtos
{
    public class UpdateSendNatficationDto : IDto
    {
        public string? UserId { get; set; }
        public string? SenderId { get; set; }
    }
}

using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.StoryVideoDtos
{
    public class UpdateStoryVideoDto : IDto
    {
        public int Id { get; set; }
        public string VideoUrl { get; set; } = null!;
    }
}

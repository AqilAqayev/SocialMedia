using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos;

public class ErrorDto : IDto
{
    public string Name { get; set; } = "Eror";
    public string Message { get; set; } = null!;
    public int StatusCode { get; set; }
}

using Microsoft.AspNetCore.Http;

namespace SocalMedia.Business.Services.Abstractions;

public interface ICloudinaryManager
{
    Task<string> FileCreateAsync(IFormFile file);
    Task<bool> FileDeleteAsync(string filePath);
}

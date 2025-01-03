using Microsoft.AspNetCore.Http;

namespace SocalMedia.Business.UiServices.Abstractions;

public interface ICloudinaryManager
{
    Task<string> FileCreateAsync(IFormFile file);
    Task<bool> FileDeleteAsync(string filePath);
    Task<string> VideoUploadAsync(IFormFile file);
    Task<bool> VideoDeleteAsync(string filePath);
}

using Microsoft.AspNetCore.Http;

namespace Mag_Blog.CoreLayer.Services.FileManager;

public interface IFileManager
{
    string SaveFile(IFormFile file, string savepath);
}
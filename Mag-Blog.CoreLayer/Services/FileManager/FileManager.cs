using Microsoft.AspNetCore.Http;

namespace Mag_Blog.CoreLayer.Services.FileManager;

public class FileManager:IFileManager
{
    public string SaveFile(IFormFile file, string savepath)
    {
        if (file == null)
            throw new Exception("File Is Null");

        var fileName = $"{Guid.NewGuid()}{file.FileName}";

        var folderPath = Path.Combine(Directory.GetCurrentDirectory(),savepath.Replace("/", "\\"));
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var fullPath = Path.Combine(folderPath, fileName);

        using var stram = new FileStream(fullPath, FileMode.Create);
        file.CopyTo(stram);
        return fileName;
    }
}
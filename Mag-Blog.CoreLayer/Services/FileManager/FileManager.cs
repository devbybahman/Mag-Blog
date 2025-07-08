using Microsoft.AspNetCore.Http;

namespace Mag_Blog.CoreLayer.Services.FileManager;

public class FileManager:IFileManager
{
    public string SaveFile(IFormFile file, string savepath)
    {
        if (file==null)
        {
            throw new Exception("file is null!");
        }

        var filename = $"{Guid.NewGuid()}{file.FileName}";
        var folderpath = Path.Combine(Directory.GetCurrentDirectory(), savepath.Replace("/","\\"));
        if (!Directory.Exists(folderpath))
        {
            Directory.CreateDirectory(folderpath);
        }

        var fullpath = Path.Combine(folderpath,filename);


        using var stram = new FileStream(fullpath, FileMode.Create);
        file.CopyTo(stram);

        return fullpath;
    }
}
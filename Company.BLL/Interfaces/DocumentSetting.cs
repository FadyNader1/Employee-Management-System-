using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Interfaces
{
    public interface DocumentSetting
    {
        public static string UploadFile(IFormFile file,string foldername)
        {
            if (file == null || file.Length == 0)
                return null;
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//files", foldername);
            var filename = $"{Guid.NewGuid()}{file.FileName}";
            var filepath = Path.Combine(folderpath, filename);
            var fs = new FileStream(filepath, FileMode.Create);
            file.CopyTo(fs);
            return filename;
        }
    }
}

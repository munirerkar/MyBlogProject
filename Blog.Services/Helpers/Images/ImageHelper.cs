using Blog.Entities.DTOs.Images;
using Blog.Entities.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Helpers.Images
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment env;
        private readonly string wwwroot;
        private const string imgFolder = "images";
        private const string articleImagesFolder = "article-images";
        private const string userImagesFolder = "user-images";

        public ImageHelper(IWebHostEnvironment env)
        {
            this.env = env;
            wwwroot = env.WebRootPath; 
        }

        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }

        public Task<ImageUploadedDto> Upload(string name, IFormFile imageFile,ImageType imageType, string folderName = null)
        {
            folderName ??= imageType == ImageType.User ? userImagesFolder : articleImagesFolder;
            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");
            }
            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string fileExtansion = Path.GetExtension(imageFile.FileName);

            name = ReplaceInvalidChars(name);
        }

        public Task Delete(string imageName)
        {
            throw new NotImplementedException();
        }

        
    }
}

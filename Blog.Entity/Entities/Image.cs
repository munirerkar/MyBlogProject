using Blog.Core.Entities;
using Blog.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Entities
{
    public class Image:EntityBase
    {
        public Image()
        {

        }
        public Image(string fileName,string fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}

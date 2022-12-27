using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("11B1A1F9-E7F7-44CC-8E3B-D408F1E59A50");
        public Image Image { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}

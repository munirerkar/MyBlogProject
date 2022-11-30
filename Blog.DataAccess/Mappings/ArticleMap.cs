using Blog.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Asp.net Core Deneme Makalesi 1",
                Content = "Lorem ipsum.",
                ViewCount = 15,
                CategoryId = Guid.Parse("A751F387-B6B6-4018-9A86-68254C85A3E4"),
                ImageId = Guid.Parse("B78F495C-995B-458E-9C49-EF26517917D6"),
                CreatedBy = "Admin Test",
                DeletedBy = "Admin Test",
                ModifiedBy = "Admin Test",
                CreatedDate = DateTime.Now,
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Deneme Makalesi 1",
                Content = "Visual Studio Lorem ipsum.",
                ViewCount = 15,
                CategoryId = Guid.Parse("93474ABA-5916-42E7-A39F-B2AD533546C0"),
                ImageId = Guid.Parse("11B1A1F9-E7F7-44CC-8E3B-D408F1E59A50"),
                CreatedBy = "Admin Test",
                DeletedBy = "Admin Test",
                ModifiedBy = "Admin Test",
                CreatedDate = DateTime.Now,
            }
            );
        }
    }
}

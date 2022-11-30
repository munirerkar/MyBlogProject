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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("A751F387-B6B6-4018-9A86-68254C85A3E4"),
                Name = "ASP.NET Core",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                DeletedBy = "Admin Test",
                ModifiedBy = "Admin Test",
            },
            new Category
            {
                Id = Guid.Parse("93474ABA-5916-42E7-A39F-B2AD533546C0"),
                Name = "Visual Studio",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                DeletedBy = "Admin Test",
                ModifiedBy = "Admin Test",
            }
            );
        }
    }
}

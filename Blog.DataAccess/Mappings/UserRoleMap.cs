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
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");
            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("2A5BC656-D774-465C-9447-6E439052872A"),
                RoleId = Guid.Parse("960D01DE-1859-48D9-ADD0-4779D0D8DB1A"),
            },
            new AppUserRole
            {
                UserId = Guid.Parse("1074D9A7-9EF6-417C-9543-B9A912D40950"),
                RoleId = Guid.Parse("8B40F3CF-0EC4-4607-A442-D4FF925A4F5F"),
            });
        }
    }
}

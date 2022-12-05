using Blog.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Context
{
    public class BlogDbContext : DbContext
    {
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-3AR1L63; Database=MyBlogDB; Trusted_Connection=True; TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer(@"Server=RUBUSOFT-WEB\SQLEXPRESS; Database=MyBlogDB; uid = ozgur; pwd = 123456; TrustServerCertificate=True;");

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

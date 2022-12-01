using Blog.Core.Entities;
using Blog.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repositories.Concrete
{
    public class Repository<T> where T : class, IEntityBase, new()
    {
        private readonly BlogDbContext dbContext;

        public Repository(BlogDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }
    }
}

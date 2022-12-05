using Blog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Abstract
{
    public interface IArticleService
    {
        Task<List<Article>> GetAllArticlesAsync();
    }
}

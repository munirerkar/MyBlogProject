using Blog.Business.Abstract;
using Blog.Business.Concrete;
using Blog.DataAccess.Repositories.Abstract;
using Blog.DataAccess.Repositories.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<IArticleService,ArticleManager>();
            return services;
        }
    }
}

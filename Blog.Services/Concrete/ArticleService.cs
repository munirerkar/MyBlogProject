using AutoMapper;
using Blog.Business.Abstract;
using Blog.Business.Extensions;
using Blog.DataAccess.UnitOfWorks;
using Blog.Entities.DTOs.Articles;
using Blog.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            //var userId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427");

            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            var imageId = Guid.Parse("B78F495C-995B-458E-9C49-EF26517917D6");

            var article = new Article(articleAddDto.Title, articleAddDto.Content, userId,userEmail, articleAddDto.CategoryId, imageId);
            
            await unitOfWork.GetRepository<Article>().AddAsync(article);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x=>!x.IsDeleted,x=>x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }
        public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId , x => x.Category);
            var map = mapper.Map<ArticleDto>(article); 
            return map;
        }
        public async Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;
            mapper.Map<ArticleUpdateDto, Article>(articleUpdateDto, article);
            await unitOfWork.GetRepository<Article>().UpdateAsync(article); 
            await unitOfWork.SaveAsync();
        }
        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedInEmail();

            var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }
    }
}

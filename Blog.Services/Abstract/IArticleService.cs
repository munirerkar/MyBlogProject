﻿using Blog.Entities.DTOs.Articles;
using Blog.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Abstract
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync();
        Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
        Task CreateArticleAsync(ArticleAddDto articleAddDto);
        Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
        Task<string> SafeDeleteArticleAsync(Guid articleId);
        Task<string> UndoDeleteArticleAsync(Guid articleId);
        Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);
    }
}

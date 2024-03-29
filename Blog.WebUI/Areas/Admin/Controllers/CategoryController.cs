﻿using AutoMapper;
using Blog.Business.Abstract;
using Blog.Business.Concrete;
using Blog.Business.Extensions;
using Blog.Entities.DTOs.Articles;
using Blog.Entities.DTOs.Categories;
using Blog.Entities.Entities;
using Blog.WebUI.Consts;
using Blog.WebUI.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IValidator<Category> validator;
        private readonly IToastNotification toast;
        private readonly IMapper mapper;

        public CategoryController(ICategoryService categoryService,IValidator<Category> validator,IToastNotification toast,IMapper mapper)
        {
            this.categoryService = categoryService;
            this.validator = validator;
            this.toast = toast;
            this.mapper = mapper;
        }
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedCategory()
        {
            var categories = await categoryService.GetAllCategoriesDeleted();
            return View(categories);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public IActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            var map = mapper.Map<Category>(categoryAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await categoryService.CreateCategoryAsync(categoryAddDto);
                toast.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            result.AddToModelState(this.ModelState);
            return View();
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDto categoryAddDto)
        {
            var map = mapper.Map<Category>(categoryAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await categoryService.CreateCategoryAsync(categoryAddDto);
                toast.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "Başarılı!" });
                return Json(Messages.Category.Add(categoryAddDto.Name));
            }
            else
            {
                toast.AddErrorToastMessage(result.Errors.FirstOrDefault().ErrorMessage, new ToastrOptions { Title = "İşlem Başarısız" });
                return Json(result.Errors.First().ErrorMessage);
            }
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            var category = await categoryService.GetCategoryByGuid(categoryId);
            var map = mapper.Map<Category, CategoryUpdateDto>(category);
            return View(map);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var map = mapper.Map<Category>(categoryUpdateDto);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                var name = await categoryService.UpdateCategoryAsync(categoryUpdateDto);
                toast.AddSuccessToastMessage(Messages.Category.Update(name), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            result.AddToModelState(this.ModelState);
            return View();
        }
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            var name = await categoryService.SafeDeleteArticleAsync(categoryId);
            toast.AddSuccessToastMessage(Messages.Category.Delete(name), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid categoryId)
        {
            var name = await categoryService.UndoDeleteArticleAsync(categoryId);
            toast.AddSuccessToastMessage(Messages.Category.Undo(name), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
    }
}

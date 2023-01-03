﻿using AutoMapper;
using Blog.Business.Abstract;
using Blog.Business.Extensions;
using Blog.Business.Helpers.Images;
using Blog.DataAccess.UnitOfWorks;
using Blog.Entities.DTOs.Users;
using Blog.Entities.Entities;
using Blog.Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;

        public UserService(IUnitOfWork unitOfWork ,IHttpContextAccessor httpContextAccessor,IMapper mapper,UserManager<AppUser> userManager,RoleManager<AppRole> roleManager,SignInManager<AppUser> signInManager,IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.imageHelper = imageHelper;
        }

        public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            map.UserName = userAddDto.Email;
            var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
            if (result.Succeeded)
            {
                var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                await userManager.AddToRoleAsync(map, findRole.ToString()); 
                return result;
            }
            else
            {
                return result;
            }
        }

        public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId)
        {
            var user = await GetAppUserByIdAsync(userId);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return (result,user.Email);
            }
            else
            {
                return (result,null);
            }
        }

        public async Task<List<AppRole>> GetAllRolesAsync()
        {
            return await roleManager.Roles.ToListAsync();
        }

        public async Task<List<UserDto>> GetAllUsersWithRoleAsync()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString()); ;
                var role = string.Join("", await userManager.GetRolesAsync(findUser));

                item.Role = role;
            }
            return map;
        }

        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            return await userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await userManager.GetRolesAsync(user));
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = await GetAppUserByIdAsync(userUpdateDto.Id);
            var userRole = await GetUserRoleAsync(user);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                await userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
                return result;
        }
        public async Task<UserProfileDto> GetUserProfileAsync()
        {
            var userId = _user.GetLoggedInUserId();
            var getUserWithImage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Image);
            var map = mapper.Map<UserProfileDto>(getUserWithImage);
            map.Image.FileName = getUserWithImage.Image.FileName;

            return map;
        }
        private async Task<Guid> UploadImageForUser(UserProfileDto userProfileDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var imageUpload = await imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
            Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, userEmail);
            await unitOfWork.GetRepository<Image>().AddAsync(image);
            return image.Id;
        }
        public async Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto)
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId);
            var isVerifed = await userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
            if (isVerifed && userProfileDto.NewPassword != null && userProfileDto.Photo != null)
            {
                var result = await userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    await signInManager.SignOutAsync();
                    await signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);
                    var map = mapper.Map(userProfileDto, user);
                    user.ImageId = await UploadImageForUser(userProfileDto);
                    await userManager.UpdateAsync(user);
                    await unitOfWork.SaveAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (isVerifed && userProfileDto.Photo != null)
            {
                await userManager.UpdateSecurityStampAsync(user);

                var map = mapper.Map(userProfileDto, user);

                var imageUpload = await imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
                Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, user.Email);
                await unitOfWork.GetRepository<Image>().AddAsync(image);

                user.ImageId = await UploadImageForUser(userProfileDto);

                await userManager.UpdateAsync(user);

                await unitOfWork.SaveAsync();
                return true;
            }
            else
                return false;
        }
    }
}
using AutoMapper;
using Blog.Business.Concrete;
using Blog.Business.Extensions;
using Blog.Business.Helpers.Images;
using Blog.DataAccess.UnitOfWorks;
using Blog.Entities.DTOs.Articles;
using Blog.Entities.DTOs.Categories;
using Blog.Entities.DTOs.Users;
using Blog.Entities.Entities;
using Blog.Entities.Enums;
using Blog.WebUI.Consts;
using Blog.WebUI.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller  
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMapper mapper;
        private readonly NToastNotify.IToastNotification toast;
        
        private readonly IValidator<AppUser> validator;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IImageHelper imageHelper;
        private readonly IUnitOfWork unitOfWork;

        public UserController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager,IMapper mapper,IToastNotification toast,IValidator<AppUser> validator,SignInManager<AppUser> signInManager,IImageHelper imageHelper,IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.toast = toast;
            this.validator = validator;
            this.signInManager = signInManager;
            this.imageHelper = imageHelper;
            this.unitOfWork = unitOfWork;
        }
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString()); ;
                var role = string.Join("",await userManager.GetRolesAsync(findUser));

                item.Role = role;
            }
            
            return View(map);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Add()
        {
            var roles = await roleManager.Roles.ToListAsync(); 
            
            return View(new UserAddDto { Roles = roles});
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            var validation = await validator.ValidateAsync(map);
            var roles = await roleManager.Roles.ToListAsync();
            if (ModelState.IsValid)
            { 
                map.UserName = userAddDto.Email;
                var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
                if (result.Succeeded)
                {
                    var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    await userManager.AddToRoleAsync(map, findRole.ToString());
                    toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Başarılı!" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDto { Roles = roles });
                }
            }

            return View(new UserAddDto { Roles = roles });
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var roles = await roleManager.Roles.ToListAsync();
            var map = mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;
            return View(map);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await userManager.FindByIdAsync(userUpdateDto.Id.ToString());
            if (user != null)
            {
                var userRole = string.Join("", await userManager.GetRolesAsync(user));
                var roles = await roleManager.Roles.ToListAsync();
                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDto, user);
                    var validation = await validator.ValidateAsync(map);
                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            await userManager.RemoveFromRoleAsync(user, userRole);
                            var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                            await userManager.AddToRoleAsync(user, findRole.Name);
                            toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Başarılı!" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            return View(new UserUpdateDto { Roles = roles });
                        }
                    }   
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto { Roles = roles });
                    }
                }
                
            }
            return NotFound();
        }
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                toast.AddSuccessToastMessage(Messages.User.Delete(user.Email), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var getImage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == user.Id,x=>x.Image);
            var map = mapper.Map<UserProfileDto>(user);
            map.Image.FileName= getImage.Image.FileName;
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {

                var isVerifed = await userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
                if (isVerifed && userProfileDto.NewPassword != null && userProfileDto.Photo != null)
                {
                    var result = await userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
                    if (result.Succeeded) 
                    { 
                        await userManager.UpdateSecurityStampAsync(user);
                        await signInManager.SignOutAsync();
                        await signInManager.PasswordSignInAsync(user,userProfileDto.NewPassword,true,false);

                        user.FirstName = userProfileDto.FirstName;
                        user.LastName = userProfileDto.LastName;
                        user.Email = userProfileDto.Email;

                        var imageUpload = await imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
                        Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, user.Email);
                        await unitOfWork.GetRepository<Image>().AddAsync(image);

                        

                        await userManager.UpdateAsync(user);

                        await unitOfWork.SaveAsync();

                        toast.AddSuccessToastMessage("Şifreniz ve bilgileriniz başarılıyla değiştirilmiştir.");
                        return View();
                    }
                    else
                    {
                        result.AddToIdentityModelState(ModelState);
                        return View();
                    }
                }
                else if (isVerifed && userProfileDto.Photo != null)
                {
                    await userManager.UpdateSecurityStampAsync(user);

                    user.FirstName = userProfileDto.FirstName;
                    user.LastName = userProfileDto.LastName;
                    user.Email = userProfileDto.Email;

                    var imageUpload = await imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
                    Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, user.Email);
                    await unitOfWork.GetRepository<Image>().AddAsync(image);



                    await userManager.UpdateAsync(user);

                    await unitOfWork.SaveAsync();


                    await userManager.UpdateAsync(user);
                    toast.AddSuccessToastMessage("Bilgileriniz başarılıyla değiştirilmiştir.");
                    return View();
                }
                else
                    toast.AddErrorToastMessage("Bilgileriniz güncellenirken bir hata oluştu");
            }
            return View();
        }
    }
}

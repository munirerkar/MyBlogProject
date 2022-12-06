using Blog.Business.Abstract;
using Blog.Business.Concrete;
using Blog.Business.Extensions;
using Blog.DataAccess.Extensions;
using Blog.DataAccess.Repositories.Abstract;
using Blog.DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadServiceLayerExtension();
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//builder.Services.AddDbContext<BlogDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
}); 

app.Run();

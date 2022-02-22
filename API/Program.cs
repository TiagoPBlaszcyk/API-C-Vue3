using Microsoft.AspNetCore.Builder;
using API.Model.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
string mySqlConnection =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<MySQLContext>(options =>
    options.UseMySql(mySqlConnection,
        ServerVersion.AutoDetect(mySqlConnection)));
 
builder.Services.AddControllersWithViews();
 
var app = builder.Build();
var scope = app.Services.CreateScope();
 
 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
 
app.UseStaticFiles();
 
app.UseRouting();
 
app.UseAuthorization();
 
 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
 
app.Run();
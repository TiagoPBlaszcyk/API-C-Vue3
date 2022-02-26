using API.Model.Context;
using Microsoft.EntityFrameworkCore;
using API.Config;
using API.Repository;
using AutoMapper;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Add services to the container.
string mySqlConnection =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<MySQLContext>(options =>
    options.UseMySql(mySqlConnection,
        ServerVersion.AutoDetect(mySqlConnection)));
 
builder.Services.AddControllersWithViews();


 
var app = builder.Build();

var scope = app.Services.CreateScope();

app.UseSwaggerUI();

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

app.UseSwagger(x => x.SerializeAsV2 = true);
 
app.Run();
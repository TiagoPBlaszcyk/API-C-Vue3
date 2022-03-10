using System.Text;
using API;
using API.Model.Context;
using Microsoft.EntityFrameworkCore;
using API.Config;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// Add services to the container.
string mySqlConnection =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<MySQLContext>(options =>
    options.UseMySql(mySqlConnection,
        ServerVersion.AutoDetect(mySqlConnection)));
 
builder.Services.AddControllersWithViews();

var key = Encoding.ASCII.GetBytes(Settings.Secret);


builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt =>
{
    jwt.RequireHttpsMetadata = false;
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder   => builder.WithOrigins(
                "http://localhost:8080",
                "localhost:8080",
                "http://localhost",
                "https://localhost")
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader());
});


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

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSwagger(x => x.SerializeAsV2 = true);

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "MyAPI V1");
});
 
app.Run();
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDo.WebApi.DAL.DatabaseContexts;
using ToDo.WebApi.DAL.Repositories.Implementations;
using ToDo.WebApi.DAL.Repositories.Interfaces;
using ToDo.WebApi.Services.Interfaces;
using ToDoApp.WebApi.DAL.Identity;
using ToDoApp.WebApi.Services.Implementations;
using ToDoApp.WebApi.Services.Interfaces;
using ToDoApp.WebApi.Services.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IToDoRepository, ToDoRepository>();

builder.Services.AddTransient<IToDoService, ToDoServices>();

builder.Services.AddTransient<IJwtService, JwtService>();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddDbContext<ToDoListDatabaseContext>(options => options.UseSqlServer(builder
    .Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ToDoListDatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();

var configuration = builder.Configuration;
var myConfigSection = configuration.GetSection("Jwt");
var mySetting = configuration.GetValue<string>("Jwt:Key");


builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(option =>
    {
        option.RequireHttpsMetadata = false;
        option.SaveToken = false;
        option.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mySetting)),
            ValidateIssuer = false, // for dev
            ValidateAudience = false, // for dev
            RequireExpirationTime = false, // for dev -- needs to be updated when refresh token is added
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

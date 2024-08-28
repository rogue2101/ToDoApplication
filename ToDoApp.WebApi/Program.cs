using Microsoft.EntityFrameworkCore;
using ToDo.WebApi.DAL.DatabaseContexts;
using ToDo.WebApi.DAL.Repositories.Implementations;
using ToDo.WebApi.DAL.Repositories.Interfaces;
using ToDo.WebApi.Services.Interfaces;
using ToDoApp.WebApi.Services.Implementations;
using ToDoApp.WebApi.Services.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IToDoRepository, ToDoRepository>();

builder.Services.AddTransient<IToDoService, ToDoServices>();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddDbContext<ToDoListDatabaseContext>(options => options.UseSqlServer(builder
    .Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

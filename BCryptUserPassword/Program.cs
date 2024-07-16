using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Contexts;
using RepositoryLayer.Interface;
using RepositoryLayer.Repository;

var builder = WebApplication.CreateBuilder(args);

// to pass the connection string
builder.Services.AddDbContext<UserContext>(cfg => cfg.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));
builder.Services.AddTransient<IUserBLL, UserBLL>();
builder.Services.AddTransient<IUserDAL, UserDAL>();
// Add services to the container.

builder.Services.AddControllers();
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

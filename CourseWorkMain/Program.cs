﻿using CourseWorkMain.DB;
using Microsoft.EntityFrameworkCore;
using CourseWorkMain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<BaseRepository>();

// äîáàâëÿåì êîíòåêñò ApplicationContext â êà÷åñòâå ñåðâèñà â ïðèëîæåíèå
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
using Microsoft.EntityFrameworkCore;
using SimpleBlogs.BLL.DTOs;
using SimpleBlogs.BLL.Interfaces;
using SimpleBlogs.BLL.Services;
using SimpleBlogs.DAL.EF;
using SimpleBlogs.DAL.Entities;
using SimpleBlogs.DAL.Interfaces;
using SimpleBlogs.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<IDataService<ArticleDTO>, ArticleService>();
builder.Services.AddScoped<IDataService<AuthorDTO>, AuthorService>();
builder.Services.AddScoped<IDataService<TagDTO>, TagService>();
builder.Services.AddScoped<IAllBlogsService, AuthorService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<Author>, EFAuthhorsRepository>();
builder.Services.AddScoped<IRepository<Article>, EFArticlesRepository>();
builder.Services.AddScoped<IRepository<Tag>, EFTagsRepository>();
builder.Services.AddScoped<IAllBlogsRepository, EFAuthhorsRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

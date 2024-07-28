using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<ICommentRepository, CommentRepository>();
//builder.Services.AddScoped<ICommentService, CommentService>();
//builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer("Server=.;Database=npm;TrustServerCertificate=True;Trusted_Connection=True;"));


builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IDiscussionRepository, DiscussionRepository>();
builder.Services.AddTransient<IDiscussionService, DiscussionService>();
builder.Services.AddTransient<ISubjectRepository, SubjectRepository>();
builder.Services.AddTransient<ISubjectService, SubjectService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();



//builder.Services.AddTransient<IMapper, Mapper>();
builder.Services.AddTransient<IContext, MyDbContext>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
    ;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

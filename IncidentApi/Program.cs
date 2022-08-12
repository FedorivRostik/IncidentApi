using Application.Services;
using DataAccess.Context;
using DataAccess.Repositories;
using Host.Configurations;
using Host.Middleware;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi.AutoMapper;
using WebApi.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
}).AddJsonOptions(jsonOptions =>
                jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<IncidentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddApplicationRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddApplicationMappers();
builder.Services.AddSystemServices();
builder.Services.AddValidations();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.AddApplicationMiddleware();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

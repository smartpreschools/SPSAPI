using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SPS.API;
using SPS.Data.Models;
using SPS.Repository.Interface;
using SPS.Repository.Repository;
using SPS.Services.Interface;
using SPS.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
  var connectionString = "Server=45.64.104.120,52894;Initial Catalog=DBSPS; uid=smartpreschool;Password=sara!@#123; Integrated Security=false;";
//var connectionString = Configuration.GetConnectionString("DefaultConnection");

//DataBase Connection
builder.Services.AddDbContext<SPSContext>(options =>
{
    options.UseSqlServer(connectionString);
});
//ApiModule.RegisterDependecy(builder.Services);
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
//Services
builder.Services.AddTransient<ICategoryService,CategoryService>();
builder.Services.AddTransient<ISubscriberService, SubscriberService>();
builder.Services.AddTransient<IPhotoGalleryFunctionService, PhotoGalleryFunctionService>();

//Repository
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<ISubscriberRepository, SubscriberRepository>();
builder.Services.AddTransient<IPhotoGalleryFunctionRepository, PhotoGalleryFunctionRepository>();


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

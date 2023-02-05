using carswebapi.Context;
using carswebapi.Services.Commands.AddCars;
using carswebapi.Services.Commands.EditCars;
using carswebapi.Services.Commands.RemoveCars;
using carswebapi.Services.FacadPatterns;
using carswebapi.Services.Queries.GetBrands;
using carswebapi.Services.Queries.GetCars;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IApiDbContext, ApiDbContext>();
builder.Services.AddScoped<IGetCarService, GetCarService>();
builder.Services.AddScoped<IGetBrandService , GetBrandService>();
builder.Services.AddScoped<IAddCarService, AddCarService>();
builder.Services.AddScoped<IRemoveCarService , RemoveCarService>();
builder.Services.AddScoped<IEditCarService , EditCarService>();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ApiDbContext>(option => option.UseSqlServer("Server=BAHAR;DataBase=Car;Trusted_Connection=true ;TrustServerCertificate=True"));


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

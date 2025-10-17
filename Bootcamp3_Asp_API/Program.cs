using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Interfaces.IServices;
using Bootcamp3_AspMVC.Interfaces;
using Bootcamp3_AspMVC.Repository;
using Bootcamp3_AspMVC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped(typeof(IRepository<>), typeof(MainRepository<>));
builder.Services.AddScoped(typeof(IRepoProduct), typeof(RepoProduct));
builder.Services.AddScoped(typeof(IRepoEmployee), typeof(RepoEmployee));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));


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

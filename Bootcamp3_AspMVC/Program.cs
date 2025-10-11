using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Interfaces;
using Bootcamp3_AspMVC.Interfaces.IServices;
using Bootcamp3_AspMVC.Repository;
using Bootcamp3_AspMVC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);





// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(50);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped(typeof(IRepository<>), typeof(MainRepository<>));
builder.Services.AddScoped(typeof(IRepoProduct), typeof(RepoProduct));
builder.Services.AddScoped(typeof(IRepoEmployee), typeof(RepoEmployee));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();

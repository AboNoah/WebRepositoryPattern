using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfWork.Core.Interfaces;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.EF.DA;
using RepositoryPatternWithUnitOfWork.EF.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region Connection
//builder.Services.AddInfrastructureServices(builder.Configuration); // Infrastructure layer services

builder.Services.AddDbContext<ApplicationDBContext>(options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));
#endregion
#region Transient
//builder.Services.AddInfrastructureServices(builder.Configuration); // Infrastructure layer services
//Repository
//builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
//Repository
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
#endregion
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfWork.EF.DA;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

#region Connection
builder.Services.AddInfrastructureServices(builder.Configuration); // Infrastructure layer services

//builder.Services.AddDbContext<ApplicationDBContext>(options => options
//                .UseSqlServer(builder.Configuration.GetConnectionString("")));
#endregion
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

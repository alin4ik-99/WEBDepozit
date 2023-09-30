using Microsoft.EntityFrameworkCore;
using WebDepozit.Data;
using WebDepozit.Services.Interface;
using WebDepozit.Services.Realization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDepozitCalculateService, DepozitCalculateService>();
builder.Services.AddScoped<DataContext>();


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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

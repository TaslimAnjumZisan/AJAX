using AJAX.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//builder.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<TransectionDbContext>(Options => Options.UseSqlServer(
               builder.Configuration.GetConnectionString("DefaultConnection")

    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Transection}/{action=Index}/{id?}");

app.Run();

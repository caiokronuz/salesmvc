using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using salesmvc.Data;
using salesmvc.Models.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<salesmvcContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("salesmvcContext"),
        new MySqlServerVersion(new Version(8, 0, 25)), // Ajuste a versão conforme necessário
        p => p.MigrationsAssembly("salesmvc")
    )
);

//register SeedingService for dependency injection system.
builder.Services.AddScoped<SeedingService>();
//register SellerService for dependency injection system.
builder.Services.AddScoped<SellerService>();
//register DepartmentService for dependency injection system.
builder.Services.AddScoped<DepartmentService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
}
else
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

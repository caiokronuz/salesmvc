using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
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
//register SalesRecordService for dependency injection system.
builder.Services.AddScoped<SalesRecordService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};

var app = builder.Build();

app.UseRequestLocalization(localizationOptions);

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

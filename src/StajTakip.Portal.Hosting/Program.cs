using Microsoft.EntityFrameworkCore;
using StajTakip.Application.Contracts.Operations;
using StajTakip.Application.Manager.Operations;
using StajTakip.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.
    var services = builder.Services;
    
    services.AddControllersWithViews();

    services.AddDbContext<StajyerModelContext>(options =>
    {
        var connectionString = "Data Source=DESKTOP-4S5AG59\\MSSQLSERVER01;"
        + "Database=StajDb;User ID=sa;Password=1;Connect Timeout=30;"
        + "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        options.UseSqlServer(connectionString);

        options
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    });

    services.AddScoped<IStajyerService, StajyerManager>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

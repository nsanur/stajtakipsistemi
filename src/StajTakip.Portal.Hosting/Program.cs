using Microsoft.EntityFrameworkCore;
using StajTakip.Application.Contracts.Operations;
using StajTakip.Application.Manager.Operations;
using StajTakip.Data.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;

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

    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
        AddCookie(option =>
        {
            // option.Cookie.Name = "NetCoreMVC.Auth";
            option.LoginPath = "/Access/Login";
            option.LogoutPath = "/Access/Logout";
            option.AccessDeniedPath = "/Error/AccessDenied";
           //option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        });

    services.AddScoped<IStajyerService, StajyerManager>();
}

var app = builder.Build();

// start of builder conf
{
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

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}
// end of builder conf

app.Run();

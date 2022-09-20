using Microsoft.EntityFrameworkCore;
using Source.Configurations;
using Source.Data;
using Source.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add application configuration from 
// database to appsettings.json
builder.Configuration.AddApplicationConfiguration();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddOptions();
builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection(nameof(SmtpOptions)));
builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection(nameof(ApiOptions)));
builder.Services.Configure<ApiOtherOptions>(builder.Configuration.GetSection(nameof(ApiOtherOptions)));
builder.Services.Configure<AuthenticationOptions>(builder.Configuration.GetSection(nameof(AuthenticationOptions)));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
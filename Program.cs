using DynamicAppSettings.Configurations;
using DynamicAppSettings.Data;
using DynamicAppSettings.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddApplicationConfiguration();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddOptions();
builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("Smtp"));
builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection("Api"));
builder.Services.Configure<ApiOtherOptions>(builder.Configuration.GetSection("ApiOther"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
using SpaceX.API.Api;
using SpaceX.BLL.Managers;
using SpaceX.BLL.Services;
using SpaceX.UI;
using SpaceX.UI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<SpaceController>();

builder.Services.AddHttpClient("ApiDataProvider", client =>
{
    client.BaseAddress = new Uri("https://api.spacexdata.com/v3/");
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ViewModelManager>();
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<IApiDataProvider, ApiDataProvider>();
builder.Services.AddScoped<ICalculationsService, CalculationsService>();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "FavoriteLaunches";
    options.IdleTimeout = TimeSpan.FromDays(365);
});


builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Space}/{action=Launches}");

app.Run();

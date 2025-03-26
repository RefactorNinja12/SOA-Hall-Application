using Hall_App.Service;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {

        
        options.SlidingExpiration = true;  
        options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
        options.LoginPath = "/Home/Login";   
        options.AccessDeniedPath = "/Home/Login";
    });

builder.Services.AddAuthorization();
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddHttpClient<ApiService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Arcadehalls}/{id?}")
    .WithStaticAssets();


app.Run();

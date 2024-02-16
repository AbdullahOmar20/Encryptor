using Services;
using ServicesContracts;
using SoftwareSecurityProject.Services;
using SoftwareSecurityProject.ServicesContract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IModernAlgorithm, Affine>();
builder.Services.AddScoped<ICeaserAlgorithm, Ceaser>();
builder.Services.AddScoped<IViginereAlgorithm, Vigenere>();



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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

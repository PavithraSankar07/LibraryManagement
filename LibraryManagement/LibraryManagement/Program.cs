using LibraryManagement.Client.Pages;
using LibraryManagement.Components;
using LibraryManagement.Components.Models;
using LibraryManagement.Components.Service;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddHttpClient();
builder.Services.AddScoped(hc => new HttpClient { BaseAddress = new Uri("http://localhost:5298") });
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<BookDetailsService>();
builder.Services.AddSingleton<BorrowDetailsService>();
builder.Services.AddAuthentication("Cookies")
.AddCookie("Cookies", options =>
{
    options.Cookie.Name = "Cookies";
    options.LoginPath = "/";
    options.AccessDeniedPath = "/accessdenied";
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // For minimal APIs/endpoint discovery
builder.Services.AddSwaggerGen(); 
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger(); // Serves the Swagger JSON endpoint
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(LibraryManagement.Client._Imports).Assembly);

app.Run();

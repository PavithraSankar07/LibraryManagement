using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using LibraryManagement.Data;
using LibraryManagement.Services;
using System.Text.Json;
using Microsoft.Extensions.Options;
using LibraryManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// builder.Services.AddSingleton<WeatherForecastService>();
// builder.Services.AddHttpClient<AuthService>(client =>
// {
//     client.BaseAddress = new Uri("http://localhost:5162/"); // replace with your API base URL
// });

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5162/") });
builder.Services.AddHttpClient("LibraryAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5162/");
})
.ConfigureHttpClient((sp, client) =>
{
    var options = sp.GetRequiredService<IOptions<JsonSerializerOptions>>().Value;
    options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
builder.Services.AddHttpClient<AuthService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5162/");
});

builder.Services.AddScoped<AuthService>(); 
builder.Services.AddScoped<UserStateService>();


builder.Services.AddScoped(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    return factory.CreateClient("LibraryAPI");
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

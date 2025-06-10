using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
 using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace LibraryManagement.Services
{
    public class AuthService
    {
    private readonly HttpClient _http;

    public AuthService(HttpClient http)
    {
        _http = http;
    }

   
 public async Task<UserDetails?> SignInAsync(string email, string password)
{
    var response = await _http.GetAsync($"api/personal/signin/{email}/{password}");
    return response.IsSuccessStatusCode
        ? await response.Content.ReadFromJsonAsync<UserDetails>()
        : null;
}

    public async Task<string> SignUpAsync(UserDetails user)
    {
        var response = await _http.PostAsJsonAsync("api/personal/signup", user);
        return response.IsSuccessStatusCode ? "Success" : await response.Content.ReadAsStringAsync();
    }
}

    }

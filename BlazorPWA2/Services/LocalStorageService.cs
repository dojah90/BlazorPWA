using System.Text.Json;
using BlazorPWA2.Interfaces;
using Microsoft.JSInterop;

namespace BlazorPWA2.Services;

public class LocalStorageService : ILocalStorageService
{
    private readonly IJSRuntime jSRuntime;

    public LocalStorageService(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    public async Task Clear()
    {
        await jSRuntime.InvokeVoidAsync("localStorage.clear");
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        string val = await jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
        if (val == null)
        {
             return default;
        }

        T? result = JsonSerializer.Deserialize<T>(val);
        return result;
    }

    public async Task RemoveAsync(string key)
    {
        await jSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
    }

    public async Task RemoveAsync<T>(T key)
    {
        if(key != null)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.removeItem", key.ToString());
        }        
    }

    public async Task SetAsync<T>(string key, T value)
    {
        string jsVal = string.Empty;
        if (value != null)
        {
            jsVal = JsonSerializer.Serialize(value);
        }

        await jSRuntime.InvokeVoidAsync("localStorage.setItem", new object[] { key, jsVal });
    }

}

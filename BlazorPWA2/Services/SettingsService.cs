using BlazorPWA2.Interfaces;
using Microsoft.JSInterop;

namespace BlazorPWA2.Services;

public class SettingsService : ISettingsService
{
    private IJSRuntime jsRuntime;
    private ILocalStorageService localStorageService;

    public SettingsService(IJSRuntime jsRuntime, ILocalStorageService localStorageService)
    {
        this.jsRuntime = jsRuntime;
        this.localStorageService = localStorageService;
    }

    public async Task SetTheme(string theme)
    {
        await localStorageService.SetAsync("theme", theme);
        var parameters = new {theme};
        await jsRuntime.InvokeVoidAsync("setTheme", theme);
    }

    public async Task<string> GetCurrentTheme(){
        return await localStorageService.GetAsync<string>("theme") ?? "theme-light";
    }
}

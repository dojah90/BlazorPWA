
using BlazorPWA2.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Pages;

public partial class Settings
{
    [Inject] private ISettingsService settingsService { get; set; }
    [Inject] private ILocalStorageService localStorageService { get; set; }

    private string currentTheme = "light";
    private string fcmToke = string.Empty;

    public string CurrentTheme{
        get => currentTheme;
        set{
            if(currentTheme != value){
                currentTheme = value;
                settingsService.SetTheme(value);
            }
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        currentTheme = await settingsService.GetCurrentTheme();
        fcmToke = await localStorageService.GetAsync<string>("FCMToken") ?? string.Empty;
    }
    public async void SwitchThemes()
    {
        if (settingsService != null)
        {
            var newTheme = string.Empty;
            var currentTheme = await settingsService.GetCurrentTheme();
            if (currentTheme.Equals("theme-light"))
            {
                newTheme = "theme-dark";
            }
            else
            {
                newTheme = "theme-light";
            }

            await settingsService.SetTheme(newTheme);
        }

    }
}

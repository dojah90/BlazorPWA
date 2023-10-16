namespace BlazorPWA2.Interfaces;

public interface ISettingsService
{
    Task SetTheme(string theme);
    Task<string> GetCurrentTheme();
}

using Microsoft.AspNetCore.Components;
namespace BlazorPWA2.Interfaces;

public interface INavigationService
{
    void RegisterEventCallback(Action callback);
    void UnregisterEventCallback(Action callback);
    void NavigateTo(string path);
    string GetCurrentPath();
}

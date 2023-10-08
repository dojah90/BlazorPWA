using Microsoft.AspNetCore.Components;
namespace BlazorPWA2.Interfaces;

public interface INavigationService
{
    void RegisterEventCallback(System.Action callback);
    void UnregisterEventCallback(System.Action callback);
    void NavigateTo(string path);
    void NavigateBack();
    bool CanNavigateBack();
    string GetCurrentPath();
}

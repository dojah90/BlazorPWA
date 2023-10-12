using BlazorPWA2.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPWA2.Services;

public class NavigationService : INavigationService
{
    private readonly NavigationManager navigationManager;
    private readonly ILogger logger;

    private IJSRuntime jsRuntime;

    private string currentPath = "/";
    private List<System.Action> eventCallbacks = new();

    private List<string> history = new();

    public NavigationService(ILogger<NavigationService> logger, NavigationManager navigationManager, IJSRuntime jsRuntime)
    {
        this.logger = logger;
        this.navigationManager = navigationManager;
        this.jsRuntime = jsRuntime;
        currentPath = GetCurrentPath();
    }

    public void RegisterEventCallback(System.Action callback)
    {
        if (eventCallbacks == null)
        {
            eventCallbacks = new();
        }

        if (eventCallbacks.Contains(callback) == false)
        {
            eventCallbacks.Add(callback);
        }
    }

    public void UnregisterEventCallback(System.Action callback)
    {
        eventCallbacks?.Remove(callback);
    }

    public async void NavigateTo(string path)
    {
        logger.Log(LogLevel.Information, path);
        if (string.IsNullOrEmpty(path) == false)
        {
            currentPath = path;

            if (history.Count == 0 || history.Last().Equals(path) == false)
            {
                history.Add(path);
            }

            await jsRuntime.InvokeVoidAsync("fadeOut");
            await Task.Delay(300);
            navigationManager.NavigateTo($"{navigationManager.BaseUri}{path}");
            await jsRuntime.InvokeVoidAsync("fadeIn");

            _ = Task.Run(() =>
            {
                foreach (var action in eventCallbacks)
                {
                    action.Invoke();
                }
            });
        }
    }

    public void NavigateBack()
    {
        if (history.Count > 0)
        {
            history.Remove(history.Last());

            if (history.Count > 0)
            {
                NavigateTo(history.Last());
            }
            else
            {
                NavigateTo("");
            }
        }
    }

    public bool CanNavigateBack()
    {
        if (history.Any() == false) return false;
        else
        {
            var path = history.Last();
            return path.Contains("/");
        }
    }

    public string GetCurrentPath()
    {
        var path = navigationManager.Uri.Remove(0, navigationManager.BaseUri.Length - 1);
        if(path.StartsWith("//")){
            path = path.Remove(0, 1);
        }

        return path;
    }
}

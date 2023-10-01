using BlazorPWA2.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Services;

public class NavigationService : INavigationService
{
    private readonly NavigationManager navigationManager;
    private readonly ILogger logger;

    private string currentPath = "/";
    private List<Action> eventCallbacks = new();

    private List<string> history = new();

    public NavigationService(ILogger<NavigationService> logger, NavigationManager navigationManager)
    {
        this.logger = logger;
        this.navigationManager = navigationManager;
        currentPath = GetCurrentPath();
    }

    public void RegisterEventCallback(Action callback)
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

    public void UnregisterEventCallback(Action callback)
    {
        eventCallbacks?.Remove(callback);
    }

    public void NavigateTo(string path)
    {
        logger.Log(LogLevel.Information, path);
        if (string.IsNullOrEmpty(path) == false)
        {
            currentPath = path;

            if (history.Count == 0 || history.Last().Equals(path) == false)
            {
                history.Add(path);
            }

            navigationManager.NavigateTo($"{navigationManager.BaseUri}{path}");

            Task.Run(() =>
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
        return navigationManager.Uri.Remove(0, navigationManager.BaseUri.Length - 1);
    }
}

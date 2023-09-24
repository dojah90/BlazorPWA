using BlazorPWA2.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Services;

public class NavigationService : INavigationService
{
    private readonly NavigationManager navigationManager;
    private readonly ILogger logger;

    private string currentPath = "/";
    private List<Action> eventCallbacks = new();

    public NavigationService(ILogger<NavigationService> logger, NavigationManager navigationManager)
    {
        this.logger = logger;
        this.navigationManager = navigationManager;
        currentPath = GetCurrentPath();
    }

    public void RegisterEventCallback(Action callback){
        if(eventCallbacks == null){
            eventCallbacks = new();
        }

        if(eventCallbacks.Contains(callback) == false){
            eventCallbacks.Add(callback);
        }
    }

    public void UnregisterEventCallback(Action callback){
        eventCallbacks?.Remove(callback);
    }

    public void NavigateTo(string path)
    {
        Console.WriteLine("WriteLine " + path);
        logger.Log(LogLevel.Information, path);
        if(string.IsNullOrEmpty(path) == false){
            currentPath = path;
            navigationManager.NavigateTo($"{navigationManager.BaseUri}{path}");

            Task.Run(() => {
                foreach(var action in eventCallbacks){
                    action.Invoke();
                }
            });
        }
    }

    public string GetCurrentPath()
    {
        return navigationManager.Uri.Remove(0, navigationManager.BaseUri.Length - 1);
    }
}

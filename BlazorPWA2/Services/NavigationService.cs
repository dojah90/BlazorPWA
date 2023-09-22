using BlazorPWA2.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Services;

public class NavigationService : INavigationService
{
    private readonly NavigationManager navigationManager;

    private string currentPath = "/";
    private List<Action> eventCallbacks = new();

    public NavigationService(NavigationManager navigationManager)
    {
        this.navigationManager = navigationManager;
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
        if(string.IsNullOrEmpty(path) == false){
            currentPath = path;
            navigationManager.NavigateTo(path);

            Task.Run(() => {
                foreach(var action in eventCallbacks){
                    action.Invoke();
                }
            });
        }
    }

    public string GetCurrentPath()
    {
        return currentPath;
    }
}

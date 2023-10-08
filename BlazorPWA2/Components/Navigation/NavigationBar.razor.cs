using BlazorPWA2.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Components.Navigation;

public partial class NavigationBar
{
    [Inject]
    private INavigationService navigationService { get; set; }
    [Inject] ILogger<NavigationBar> logger { get; set; }
    
    private string currentPath = "/";

    protected override void OnInitialized()
    {
        base.OnInitialized();
        navigationService.RegisterEventCallback(OnNavigationEvent);
        currentPath = navigationService.GetCurrentPath();
    }

    private void OnNavigationEvent(){
        currentPath = navigationService.GetCurrentPath();
        StateHasChanged();
    }

    private string GetCssClass(string path)
    {
        var result = "nav-bar-icon";

        if(currentPath.StartsWith(path)){
            result += " nav-bar-icon-selected";
        }

        return result;
    }

    private void NavigateTo(string path){
        navigationService.NavigateTo(path);
    }
}

using BlazorPWA2.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Components.Navigation;

public partial class NavigationBar
{
    [Inject]
    private INavigationService navigationService { get; set; }
    private string currentPath = "/";

    protected override void OnInitialized()
    {
        base.OnInitialized();
        navigationService.RegisterEventCallback(OnNavigationEvent);
    }

    private void OnNavigationEvent(){
        currentPath = navigationService.GetCurrentPath();
        StateHasChanged();
    }

    private string GetCssClass(string path)
    {
        var result = "nav-bar-icon";

        if(currentPath.Equals(path)){
            result += " nav-bar-icon-selected";
        }

        return result;
    }

    private void NavigateTo(string path){
        navigationService.NavigateTo(path);
    }
}

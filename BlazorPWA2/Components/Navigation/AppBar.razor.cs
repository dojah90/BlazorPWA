using BlazorPWA2.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorPWA2.Components.Navigation;

public partial class AppBar
{
    [Parameter]
    public string Title { get; set; } = string.Empty;

    [Parameter]
    public List<Action> Actions { get; set; } = new();

    [Inject] private INavigationService? navigationService { get; set; }

    private bool canNavBack => navigationService?.CanNavigateBack() ?? false;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        navigationService?.RegisterEventCallback(OnNavigation);
    }

    private void OnNavigation()
    {
        StateHasChanged();
    }

    private void GoBack()
    {
        navigationService?.NavigateBack();
    }
}

namespace BlazorPWA2;

public class Action
{
    public string IconPath { get; set; } = string.Empty;
    public System.Action OnClicked { get; set; }
}

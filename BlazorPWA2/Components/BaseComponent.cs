namespace BlazorPWA2;

public abstract class BaseComponent<T>
{
    public ILogger<T> Logger { get; set; }

    public BaseComponent(ILogger<T> logger)
    {
        Logger = logger;
    }
}

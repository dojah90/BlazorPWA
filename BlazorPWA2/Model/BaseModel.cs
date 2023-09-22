namespace BlazorPWA2.Model;

public abstract class BaseModel
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
    public DateTime Deleted { get; set; }
}

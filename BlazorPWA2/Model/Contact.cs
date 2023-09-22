namespace BlazorPWA2.Model;

public class Contact : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Alias { get; set; }
    public DateOnly? Birthday { get; set; }

}

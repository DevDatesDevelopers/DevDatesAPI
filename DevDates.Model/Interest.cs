namespace DevDates.Model;

public record Interest
{
    public string DisplayName { get; set; }
    public Photo[] Photos { get; set; }
}
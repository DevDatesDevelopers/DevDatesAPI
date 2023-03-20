namespace DevDates.Model;

public record SexualPreference
{
    public string DisplayName { get; init; }
    public Photo[] Photos { get; init; }
}
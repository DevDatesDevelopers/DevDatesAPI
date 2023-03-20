namespace DevDates.Model;

public class User
{
    public ShortUserInfo ShortInfo { get; set; }
    public DetailedUserInfo DetailedInfo { get; set; }
    public ConnectedService[] ConnectedServices { get; set; }
}

public record ShortUserInfo
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public SexualPreference[] SexualPreferences { get; set; }
    public Photo[] Photos { get; set; }
}

public record DetailedUserInfo
{
    public string Bio { get; set; }
    public Interest[] Interests { get; set; }
}
namespace DevDates.Model.ViewModels;

/// <summary>
/// The User class which holds 3 properties: ShortInfo, DetailedInfo, and ConnectedServices
/// </summary>
public class ViewModelUser
{
    public ShortUserInfo ShortInfo { get; set; }
    public DetailedUserInfo DetailedInfo { get; set; }
    public ConnectedService[] ConnectedServices { get; set; }
}

/// <summary>
/// This is class with name ShortUserInfo who contains 5 properties for User: Name, Age, Gender, SexualPreference and photos
/// </summary>
public record ShortUserInfo
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public SexualPreference[] SexualPreferences { get; set; }
    public Photo[] Photos { get; set; }
}

/// <summary>
/// This class DetailedUserInfo contains the bio plus the property Interest
/// </summary>
public record DetailedUserInfo
{
    public string Bio { get; set; }
    public ViewModelInterest[] Interests { get; set; }
}
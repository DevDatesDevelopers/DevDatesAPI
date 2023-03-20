namespace DevDates.Model.Models;
/// <summary>
/// In this class we create three properties
/// </summary>
public class User
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
/// This class DetailedUserInfo contains the class ShortUserinfo plus the property Interest
/// </summary>
public record DetailedUserInfo
{
    public ShortUserInfo ShortInfo { get; set; }
    public string Bio { get; set; }
    public Interest[] Interests { get; set; }
}
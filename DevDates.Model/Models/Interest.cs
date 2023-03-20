namespace DevDates.Model.Models
{
    /// <summary>
    /// This class is for interest of user and have two properties: Name-"DisplayName", and icon-"Photo"
    /// </summary>
    public class Interest
    {
        public string DisplayName { get; set; }
        public Photo[] Photos { get; set; }
    }
}

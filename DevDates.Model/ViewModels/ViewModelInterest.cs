namespace DevDates.Model.ViewModels
{
    /// <summary>
    /// This class is for interest of user and have two properties: Name-"DisplayName", and icon-"Photo"
    /// </summary>
    public class ViewModelInterest
    {
        public string DisplayName { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
    }
}

namespace DevDates.Model.ViewModels
{
    /// <summary>
    /// This class is for user sexual preference, have name:"DisplayName" and icon:"Photos"
    /// </summary>
    public class SexualPreference
    {
        public int Id { get; set; }
        public string DisplayName { get; init; }
        public Photo Photo { get; init; }
    }
}

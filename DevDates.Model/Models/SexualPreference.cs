﻿namespace DevDates.Model.Models
{
    /// <summary>
    /// This class is for user sexual preference, have name:"DisplayName" and icon:"Photos"
    /// </summary>
    public class SexualPreference
    {
        public string DisplayName { get; init; }
        public Photo[] Photos { get; init; }
    }
}

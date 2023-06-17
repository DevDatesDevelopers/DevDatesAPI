using System;
using System.Collections.Generic;


namespace DevDates.DBModel.Data.Models;

public class UsersPreference
{
    public string UserId { get; set; }

    public int GenderId { get; set; }

    public DateTime? Created { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

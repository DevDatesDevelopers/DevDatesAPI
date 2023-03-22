using System;
using System.Collections.Generic;

namespace DevDates.DBModel.Data.Models;

public class Interest
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Resource> Resources { get; } = new List<Resource>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}

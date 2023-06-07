using System;
using System.Collections.Generic;

namespace DevDates.DBModel.Data.Models;

public class ResourcesType
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();
}

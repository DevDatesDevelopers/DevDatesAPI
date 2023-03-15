using System;
using System.Collections.Generic;


namespace DevDates.DBModel.Data.Models;

public class Resource
{
    public int Id { get; set; }

    public string? ResourceUri { get; set; }

    public int? ResourceTypeId { get; set; }

    public virtual ResourcesType? ResourceType { get; set; }

    public virtual ICollection<Gender> Genders { get; } = new List<Gender>();

    public virtual ICollection<Interest> Interests { get; } = new List<Interest>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}

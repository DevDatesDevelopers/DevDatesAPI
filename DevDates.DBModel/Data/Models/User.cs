using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevDates.DBModel.Data.Models;

public class User
{
    [Key]
    public string Id { get; set; }

    public string? Name { get; set; }

    public DateTime? DateOfBirth { get; set; }
    public int? GenderId { get; set; }

    public string? Bio { get; set; }

    public string? Email { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public string? ModifiedBy { get; set; }
    

    public virtual Gender? Gender { get; set; }

    public virtual ICollection<Like> LikeLikeds { get; } = new List<Like>();

    public virtual ICollection<Like> LikeLikers { get; } = new List<Like>();

    public virtual ICollection<UsersPreference> UsersPreferences { get; } = new List<UsersPreference>();

    public virtual ICollection<Interest> Interests { get; set; } = new List<Interest>();

    public virtual ICollection<Resource> Resources { get; } = new List<Resource>();
}

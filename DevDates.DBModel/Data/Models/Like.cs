using System;
using System.Collections.Generic;


namespace DevDates.DBModel.Data.Models;

public class Like
{
    public int LikerId { get; set; }

    public int LikedId { get; set; }

    public DateTime? Created { get; set; }

    public virtual User Liked { get; set; } = null!;

    public virtual User Liker { get; set; } = null!;
}

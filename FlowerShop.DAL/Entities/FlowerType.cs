using System;
using System.Collections.Generic;

namespace FlowerShop.DAL.Entities;

public partial class FlowerType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Typeandpost> Typeandposts { get; set; } = new List<Typeandpost>();
}

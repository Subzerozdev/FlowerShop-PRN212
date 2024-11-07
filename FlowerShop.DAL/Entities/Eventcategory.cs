using System;
using System.Collections.Generic;

namespace FlowerShop.DAL.Entities;

public partial class EventCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}

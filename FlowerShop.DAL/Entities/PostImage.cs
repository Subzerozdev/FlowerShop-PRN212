using System;
using System.Collections.Generic;

namespace FlowerShop.DAL.Entities;

public partial class PostImage
{
    public int Id { get; set; }

    public int? PostId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Post? Post { get; set; }
}

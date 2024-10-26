using System;
using System.Collections.Generic;

namespace FlowerShop.DAL.Entities;

public partial class Typeandpost
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public int PostId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual FlowerType Type { get; set; } = null!;
}

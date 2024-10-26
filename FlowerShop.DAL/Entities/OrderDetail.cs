using System;
using System.Collections.Generic;

namespace FlowerShop.DAL.Entities;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int? NumberOfProducts { get; set; }

    public double? TotalMoney { get; set; }

    public int OrderId { get; set; }

    public int PostId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;
}

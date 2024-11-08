using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlowerShop.DAL.Entities;

public partial class OrderDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public double? TotalMoney { get; set; }

    public int OrderId { get; set; }

    public int PostId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;
}

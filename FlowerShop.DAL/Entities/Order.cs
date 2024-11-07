using System;
using System.Collections.Generic;

namespace FlowerShop.DAL.Entities;

public partial class Order
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Note { get; set; }

    public string? PaymentMethod { get; set; }

    public DateTime? OrderDate { get; set; }

    public double? TotalMoney { get; set; }

    public string? Status { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User? User { get; set; }
}

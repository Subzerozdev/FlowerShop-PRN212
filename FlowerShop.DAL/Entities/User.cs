using System;
using System.Collections.Generic;

namespace FlowerShop.DAL.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime? CreateAt { get; set; }

    public bool? IsActive { get; set; }

    public byte? RoleId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual Role? Role { get; set; }
}

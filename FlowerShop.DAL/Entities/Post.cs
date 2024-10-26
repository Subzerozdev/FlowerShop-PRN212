using System;
using System.Collections.Generic;

namespace FlowerShop.DAL.Entities;

public partial class Post
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Thumbnail { get; set; }

    public string? Address { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public double Price { get; set; }

    public int UserId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Eventcategory? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<PostImage> PostImages { get; set; } = new List<PostImage>();

    public virtual ICollection<Typeandpost> Typeandposts { get; set; } = new List<Typeandpost>();

    public virtual User User { get; set; } = null!;
}

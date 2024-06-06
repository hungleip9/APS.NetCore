using System;
using System.Collections.Generic;

namespace ASPNetCore.Models;

public partial class Category
{
    public string? CategoryName { get; set; }

    public int Id { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}

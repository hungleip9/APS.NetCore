using System;
using System.Collections.Generic;

namespace ASPNetCore.Models;

public partial class Post
{
    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Teaser { get; set; }

    public string? ViewCount { get; set; }

    public int Id { get; set; }

    public int? CateId { get; set; }

    public virtual Category? Cate { get; set; }
}

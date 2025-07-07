﻿using Mag_Blog.CoreLayer.DTOs.Categories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mag_Blog.CoreLayer.DTOs.Posts;

public class PostDto
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }

    public string Slug { get; set; }
    public string ImageName { get; set; }
    public DateTime CreationDate { get; set; }
    public CategoryDTO Category { get; set; }
    public int Visited { get; set; }
}
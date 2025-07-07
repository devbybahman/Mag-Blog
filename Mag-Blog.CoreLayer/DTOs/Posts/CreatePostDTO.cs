﻿namespace Mag_Blog.CoreLayer.DTOs.Posts;

public class CreatePostDTO
{
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }

    public string Slug { get; set; }
}
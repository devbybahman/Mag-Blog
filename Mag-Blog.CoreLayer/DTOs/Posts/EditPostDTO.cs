﻿using Microsoft.AspNetCore.Http;

namespace Mag_Blog.CoreLayer.DTOs.Posts;

public class EditPostDTO
{
    public int PostId { get; set; }
    public int CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    public string Title { get; set; }
    
    public string Description { get; set; }

    public string Slug { get; set; }
    public IFormFile ImageFile { get; set; }

}
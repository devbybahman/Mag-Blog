﻿namespace Mag_Blog.CoreLayer.DTOs.Categories;

public class EditCategoryDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public string Slug { get; set; }
    
    
    public string MetaTag { get; set; }
    
    public string MetaDescription { get; set; }
    
    
}
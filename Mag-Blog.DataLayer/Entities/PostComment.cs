namespace Mag_Blog.DataLayer.Entities;

public class PostComment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    
}
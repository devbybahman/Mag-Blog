using System.ComponentModel.DataAnnotations;

namespace Mag_Blog.DataLayer;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsDeleted { get; set; }
}
using Mag_Blog.DataLayer.Entities;

namespace Mag_Blog.CoreLayer.DTOs;

public class UserDTO
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public UserRole Role { get; set; }
    public DateTime RegisterDate { get; set; }
}
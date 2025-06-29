using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mag_Blog.DataLayer.Entities;

public class User
{
    public int  Id { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Password    { get; set; }
    public UserRole Role { get; set; }
}

public enum UserRole
{
    Admin,
    User,
    Author
}
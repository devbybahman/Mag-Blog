
using BCrypt.Net;
namespace CodeYad_Blog.CoreLayer.Utilities;
public static class Encoder
{
   
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
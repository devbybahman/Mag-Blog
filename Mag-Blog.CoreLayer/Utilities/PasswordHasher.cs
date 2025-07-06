
using BCrypt.Net;
namespace CodeYad_Blog.CoreLayer.Utilities;
public static class PasswordHasher
{
   
    public static string HashPassword(this string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string password, string hashpassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashpassword);
    }
}
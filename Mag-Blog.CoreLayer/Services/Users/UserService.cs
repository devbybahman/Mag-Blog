using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs;
using Mag_Blog.CoreLayer.DTOs.Users;
using Mag_Blog.DataLayer.Context;
using Mag_Blog.DataLayer.Entities;

namespace Mag_Blog.CoreLayer.Services.Users;

public class UserService:IUserService
{
    private readonly BlogCobtext _context;

    public UserService(BlogCobtext context)
    {
        _context = context;
    }

    public OperationResult Register(UserRegisterDTO registerDto)
    {
        var SameUser = _context.Users.Any(p => p.UserName == registerDto.UserName);
        if (SameUser)
            return OperationResult.Error("این نام کاربری مجاز نیست");
        

        var HashPass = PasswordHasher.HashPassword(registerDto.Password);
        _context.Users.Add(new User()
        {
            UserName = registerDto.UserName,
            FullName = registerDto.FullName,
            Password = HashPass,
            IsDeleted = false,
            CreationDate = DateTime.Now,
            Role = UserRole.User
        });
        _context.SaveChanges();
        return OperationResult.Success();
    }

    public UserDTO Login(UserLoginDTO LoginDto)
    {
        var user = _context.Users.FirstOrDefault(p => p.UserName == LoginDto.UserName);
        if (user == null)
            return null;

        bool isPasswordValid = PasswordHasher.VerifyPassword(LoginDto.Password, user.Password);
        if (!isPasswordValid)
            return null;

        UserDTO userDto = new UserDTO()
        {
            Password = user.Password,
            UserName = user.UserName,
            UserId = user.Id,
            RegisterDate = user.CreationDate,
            FullName = user.FullName,
            Role = user.Role
        };
        return userDto;
    }
}
using CodeYad_Blog.CoreLayer.Utilities;
using Mag_Blog.CoreLayer.DTOs.Users;

namespace Mag_Blog.CoreLayer.Services.Users;

public interface IUserService
{
    OperationResult Register(UserRegisterDTO registerDto);
    OperationResult Login(UserLoginDTO LoginDto);
}
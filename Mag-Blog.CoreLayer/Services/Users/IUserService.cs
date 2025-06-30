using Mag_Blog.CoreLayer.DTOs.Users;

namespace Mag_Blog.CoreLayer.Services.Users;

public interface IUserService
{
    void Register(UserRegisterDTO registerDto);
}
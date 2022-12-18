using BusinessLayer.Model.DTOs.UserDTOs;
using BusinessLayer.Token;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        AccessToken Login(UserLoginDto userLoginDto);
    }
}

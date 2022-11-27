using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Repository
{
    public interface IUserRepository
    {
        User ValidateCredential(UserVO userVO);

        User ValidateCredential(string username);
        bool RevokeToken(string username);

        User RefreshUserInfo(User user);
    }
}

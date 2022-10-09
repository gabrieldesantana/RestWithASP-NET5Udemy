using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Repository
{
    public interface IUserRepository
    {
        User ValidateCredential(UserVO userVO);

        User RefreshUserInfo(User user);
    }
}

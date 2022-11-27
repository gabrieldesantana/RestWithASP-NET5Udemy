using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO userVO);
        TokenVO ValidateCredentials(TokenVO tokenVO);

        bool RevokeToken(string username);
    }
}

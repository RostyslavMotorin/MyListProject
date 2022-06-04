using MyList.Domain.Common.Models;

namespace MyList.Application.Common.Interfaces
{
    public interface IAuthorizeService
    {
        Task<UserToken> RegisterUser(RegisterModel model);
        Task<UserToken> LogInUser(LoginModel model);
    }
}

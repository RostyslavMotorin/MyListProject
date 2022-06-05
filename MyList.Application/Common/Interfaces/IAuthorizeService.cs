using MyList.Application.Common.Dto;
using MyList.Domain.Common.Models;

namespace MyList.Application.Common.Interfaces
{
    public interface IAuthorizeService
    {
        Task<IdentityLoginDto> RegisterUser(RegisterModel model);
        Task<IdentityLoginDto> LogInUser(LoginModel model);
    }
}

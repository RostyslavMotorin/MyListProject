using MyList.Domain.Common.Models;

namespace MyList.Domain.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}

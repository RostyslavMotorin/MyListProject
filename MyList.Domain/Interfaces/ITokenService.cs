using MyList.Data.Models;

namespace MyList.Domain.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}

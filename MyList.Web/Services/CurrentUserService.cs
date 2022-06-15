using System.Security.Claims;
using MyList.Application.Common.Interfaces;

namespace MyList.Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor http_httpContextAccessor)
        {
            _httpContextAccessor = http_httpContextAccessor;
        }

        public Guid? UserId
        {
            get
            {
                var id = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                if(id != null && Guid.TryParse(id, out var userId))
                    return userId;
                return null;
            }
        }

        public bool IsAuthorized => UserId != null;

        public bool IsInRole(string roleName)
        {
            return _httpContextAccessor.HttpContext?.User.IsInRole(roleName) ?? false;
        }
    }
}

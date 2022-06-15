namespace MyList.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Guid? UserId { get; }
        bool IsAuthorized { get; }
        bool IsInRole(string roleName);
    }
}

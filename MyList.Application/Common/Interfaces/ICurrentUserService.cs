using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        int? UserUd { get; }
        bool IsAuthorized { get; }
        bool IsInRole(string roleName);
    }
}

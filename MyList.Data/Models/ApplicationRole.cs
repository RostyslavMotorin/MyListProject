using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MyList.Data.Models
{
    [Table("Roles")]
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    }
}

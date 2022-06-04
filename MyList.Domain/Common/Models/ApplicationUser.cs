using Microsoft.AspNetCore.Identity;
using MyList.Domain.Common.Models.ContentModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyList.Domain.Common.Models
{
    [Table("Users")]
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string Gender { get; set; } = String.Empty; //enum
        public string PhotoURL { get; set; } = String.Empty;
        public ICollection<ApplicationRole> Roles { get; set; } = new List<ApplicationRole>();
        //Collections
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<Serial> Serials { get; set; } = new List<Serial>();
        public ICollection<Anime> Anime { get; set; } = new List<Anime>();
        public ICollection<Film> Films { get; set; } = new List<Film>();
        public ICollection<Game> Games { get; set; } = new List<Game>();


    }
}

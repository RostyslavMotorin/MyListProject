using Microsoft.AspNetCore.Identity;
using MyList.Data.Models.ContentModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyList.Data.Models
{
    [Table("Users")]
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string Gender { get; set; } //enum
        public string PhotoURL { get; set; }
        public ICollection<ApplicationRole> Roles { get; set; } = new List<ApplicationRole>();
        //Collections
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<Serial> Serials { get; set; } = new List<Serial>();
        public ICollection<Anime> Anime { get; set; } = new List<Anime>();
        public ICollection<Film> Films { get; set; } = new List<Film>();
        public ICollection<Game> Games { get; set; } = new List<Game>();


    }
}

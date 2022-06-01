using Microsoft.AspNetCore.Identity;
using MyList.Data.Models.ContentModels;

namespace MyList.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Gender { get; set; } //enum
        public string PhotoURL { get; set; }
        public Role role { get; set; }
        
        //Collections
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<Serial> Serials { get; set; } = new List<Serial>();
        public ICollection<Anime> Anime { get; set; } = new List<Anime>();
        public ICollection<Film> Films { get; set; } = new List<Film>();
        public ICollection<Game> Games { get; set; } = new List<Game>();


    }
}

using System.ComponentModel.DataAnnotations;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Domain.Common.Models.Tags
{
    public class FilmTag
    {
        [Key]
        public Guid TagID { get; set; }
        public string Name { get; set; }
        public ICollection<Film>? Films { get; set; } = new List<Film>();
    }
}

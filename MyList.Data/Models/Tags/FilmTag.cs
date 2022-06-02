using System.ComponentModel.DataAnnotations;

namespace MyList.Data.Models.Tags
{
    public class FilmTag
    {
        [Key]
        public Guid TagID { get; set; }
        public string Name { get; set; }
    }
}

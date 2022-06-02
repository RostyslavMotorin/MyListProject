using System.ComponentModel.DataAnnotations;
using MyList.Data.Models.Tags;

namespace MyList.Data.Models.ContentModels
{
    public class Film
    {
        [Key]
        public Guid FilmID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public ICollection<FilmTag> Tags { get; set; } = new List<FilmTag>();
        public int UserScore { get; set; } //enum
        public int GlobalScore { get; set; } //enum
        public string UserStatus { get; set; } //enum
        public string GlobalStatus { get; set; } //enum
        public ICollection<Creators> Authors { get; set; } = new List<Creators>();
        public DateTime RelizeDate { get; set; }
    }
}

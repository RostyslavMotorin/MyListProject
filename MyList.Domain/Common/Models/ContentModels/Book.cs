using System.ComponentModel.DataAnnotations;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Domain.Common.Models.ContentModels
{
    public class Book
    {
        [Key]
        public Guid BookID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public ICollection<BookTag> Tags { get; set; } = new List<BookTag>();
        public int UserScore { get; set; } //enum
        public int GlobalScore { get; set; } //enum
        public string UserStatus { get; set; } //enum
        public string GlobalStatus { get; set; } //enum
        public ICollection<Creators> Authors { get; set; } = new List<Creators>();
        public string BookSeries { get; set; }
        public DateTime RelizeDate { get; set; }
    }
}

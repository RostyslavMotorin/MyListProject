using MyList.Data.Models.Tags;

namespace MyList.Data.Models.ContentModels
{
    public class Book
    {
        public Guid BookID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public ICollection<BookTag> Tags { get; set; } = new List<BookTag>();
        public int UserScore { get; set; }
        public int GlobalScore { get; set; }
        public string UserStatus { get; set; }
        public string GlobalStatus { get; set; }
        public ICollection<Creators> Authors { get; set; } = new List<Creators>();
        public string BookSeries { get; set; }
        public DateTime RelizeDate { get; set; }
    }
}

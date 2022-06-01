using MyList.Data.Models.Tags;

namespace MyList.Data.Models.ContentModels
{
    public class Game
    {
        public Guid GameID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public ICollection<GameTag> Tags { get; set; } = new List<GameTag>();
        public int UserScore { get; set; } //enum
        public int GlobalScore { get; set; } //enum
        public string UserStatus { get; set; } //enum
        public string GlobalStatus { get; set; } //enum
        public string GameStudio { get; set; }
        public DateTime RelizeDate { get; set; }
    }
}

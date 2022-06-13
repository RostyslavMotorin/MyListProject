using System.ComponentModel.DataAnnotations;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Domain.Common.Models.ContentModels
{
    public class Anime
    {
        [Key]
        public Guid AnimeID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? PictureURL { get; set; }
        public ICollection<AnimeTag>? Tags { get; set; } = new List<AnimeTag>();
        public float? UserScore { get; set; } //enum
        public float? GlobalScore { get; set; } //enum
        public int? CountEpisodes { get; set; }
        public string? UserStatus { get; set; } //enum
        public string? GlobalStatus { get; set; } //enum
        public ICollection<Creators>? Authors { get; set; } = new List<Creators>();
        public DateTime? RelizeDate { get; set; }
    }
}

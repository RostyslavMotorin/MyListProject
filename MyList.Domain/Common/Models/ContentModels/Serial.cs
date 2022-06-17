using System.ComponentModel.DataAnnotations;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Domain.Common.Models.ContentModels
{
    public class Serial
    {
        [Key]
        public Guid SerialID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? PictureURL { get; set; }
        public ICollection<SerialTag>? Tags { get; set; } = new List<SerialTag>();
        public float? UserScore { get; set; } //enum
        public float? GlobalScore { get; set; } //enum
        public int? CountEpisodes { get; set; }
        public string? UserStatus { get; set; } //enum
        public string? GlobalStatus { get; set; } //enum
        public ICollection<Creators>? Authors { get; set; } = new List<Creators>();
        public DateTime? RelizeDate { get; set; }
        public Guid? ApplicationUserId { get; set; }
    }
}

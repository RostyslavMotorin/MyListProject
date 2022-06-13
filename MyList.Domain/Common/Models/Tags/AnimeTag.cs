using System.ComponentModel.DataAnnotations;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Domain.Common.Models.Tags
{
    public class AnimeTag
    {
        [Key]
        public Guid TagID { get; set; }
        public string Name { get; set; }
        public ICollection<Anime>? Anime { get; set; } = new List<Anime>();
    }
}

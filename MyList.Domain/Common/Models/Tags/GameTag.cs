using System.ComponentModel.DataAnnotations;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Domain.Common.Models.Tags
{
    public class GameTag
    {
        [Key]
        public Guid TagID { get; set; }
        public string Name { get; set; }
        public ICollection<Game>? Games { get; set; } = new List<Game>();
    }
}

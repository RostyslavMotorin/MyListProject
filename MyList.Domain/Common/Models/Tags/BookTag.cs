using System.ComponentModel.DataAnnotations;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Domain.Common.Models.Tags
{
    public class BookTag
    {
        [Key]
        public Guid TagID { get; set; }
        public string Name { get; set; }
        public ICollection<Book>? Books { get; set; } = new List<Book>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace MyList.Data.Models.Tags
{
    public class GameTag
    {
        [Key]
        public Guid TagID { get; set; }
        public string Name { get; set; }
    }
}

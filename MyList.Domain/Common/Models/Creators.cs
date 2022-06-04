using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyList.Domain.Common.Models
{
    [Table("Creators")]
    public class Creators
    {
        [Key]
        public Guid CreatorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public DateTime Birth { get; set; }
    }
}

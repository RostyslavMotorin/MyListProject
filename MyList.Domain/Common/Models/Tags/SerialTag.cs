using System.ComponentModel.DataAnnotations;

namespace MyList.Domain.Common.Models.Tags
{
    public class SerialTag
    {
        [Key]
        public Guid TagID { get; set; }
        public string Name { get; set; }
    }
}

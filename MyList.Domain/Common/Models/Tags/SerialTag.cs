using System.ComponentModel.DataAnnotations;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Domain.Common.Models.Tags
{
    public class SerialTag
    {
        [Key]
        public Guid TagID { get; set; }
        public string Name { get; set; }
        public ICollection<Serial> Serials { get; set; } = new List<Serial>();
    }
}

using Microsoft.AspNetCore.Http;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Application.Common.Dto
{
    public class GameDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        //public IFormFile Picture { get; set; }
        public ICollection<GameTag>? Tags { get; set; } = new List<GameTag>();
        public string? GameStudio { get; set; }
    }
}

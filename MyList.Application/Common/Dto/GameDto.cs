using Microsoft.AspNetCore.Http;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Application.Common.Dto
{
    public class GameDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public ICollection<TagDto>? Tags { get; set; }
        public string? GameStudio { get; set; }
    }
}

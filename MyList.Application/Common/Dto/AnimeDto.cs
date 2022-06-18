namespace MyList.Application.Common.Dto
{
    public class AnimeDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public float? GlobalScore { get; set; }
        public ICollection<TagDto>? Tags { get; set; }
    }
}

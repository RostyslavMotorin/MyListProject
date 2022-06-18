namespace MyList.Application.Common.Dto
{
    public class BookDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public float? GlobalScore { get; set; }
        public ICollection<TagDto>? Tags { get; set; }
        public string? BookSeries { get; set; }
    }
}

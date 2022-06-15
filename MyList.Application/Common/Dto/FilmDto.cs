﻿namespace MyList.Application.Common.Dto
{
    public class FilmDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public ICollection<TagDto>? Tags { get; set; }
    }
}
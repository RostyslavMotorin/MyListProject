﻿using System.ComponentModel.DataAnnotations;
using MyList.Data.Models.Tags;

namespace MyList.Data.Models.ContentModels
{
    public class Serial
    {
        [Key]
        public Guid SerialID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public ICollection<SerialTag> Tags { get; set; } = new List<SerialTag>();
        public int UserScore { get; set; } //enum
        public int GlobalScore { get; set; } //enum
        public int CountEpisodes { get; set; }
        public string UserStatus { get; set; } //enum
        public string GlobalStatus { get; set; } //enum
        public ICollection<Creators> Authors { get; set; } = new List<Creators>();
        public DateTime RelizeDate { get; set; }
    }
}

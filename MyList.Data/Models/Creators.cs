namespace MyList.Data.Models
{
    public class Creators
    {
        public Guid CreatorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public DateTime Birth { get; set; }
    }
}

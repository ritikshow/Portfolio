namespace Portfolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string subTitle { get; set; }
        public string Description { get; set; }
        public string? Websitelink { get; set; }
        public string PLogo { get; set; }
        public string? githublink { get; set; }
        public string? reportP { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastModified { get; set; } = DateTime.UtcNow;


    }
}

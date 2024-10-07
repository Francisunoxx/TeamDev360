namespace TeamDev360.Models
{
    public class ExternalLinks
    {
        public List<SocialLink> Twitter { get; set; }
        public List<SocialLink> ITunes { get; set; }
        public List<SocialLink> LastFm { get; set; }
    }

    public class SocialLink
    {
        public string Url { get; set; }
    }
}


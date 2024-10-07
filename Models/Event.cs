using System.Text.Json.Serialization;

namespace TeamDev360.Models
{
    public class Event
    {
        [JsonPropertyName("_embedded")]
        public Embedded Embedded { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public List<Image> Images { get; set; }
        public Dates Dates { get; set; }
        public Country Country { get; set; }
        public Address Address { get; set; }
        //public ExternalLinks? ExternalLinks { get; set; }
    }
}
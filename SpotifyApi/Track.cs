using Newtonsoft.Json;

namespace SpotifyApi
{
    public class Track
    {
        public bool Available { get; set; }
        public string Href { get; set; }
        public string Name { get; set; }
        public string Popularity { get; set; }
        public Artist[] Artists { get; set; }
        public Album Album { get; set; }
        public double Length { get; set; }

        [JsonProperty(PropertyName = "track-number")]
        public int TrackNumber { get; set; }

        [JsonProperty(PropertyName = "external-ids")]
        public ExternalId[] ExternalIds { get; set; }
    }
}

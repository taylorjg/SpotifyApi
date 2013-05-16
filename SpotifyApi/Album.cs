using Newtonsoft.Json;

namespace SpotifyApi
{
    public class Album
    {
        public string Name { get; set; }
        public string Popularity { get; set; }

        [JsonProperty(PropertyName = "external-ids")]
        public ExternalId[] ExternalIds { get; set; }

        [JsonProperty(PropertyName = "artist-id")]
        public string ArtistId { get; set; }

        public string Href { get; set; }
        public Artist[] Artists { get; set; }
        public Track[] Tracks { get; set; }
        public Availability Availability { get; set; }
        public string Released { get; set; }
    }
}

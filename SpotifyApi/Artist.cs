using Newtonsoft.Json;

namespace SpotifyApi
{
    public class Artist
    {
        public string Href { get; set; }
        public string Name { get; set; }

        [JsonProperty(PropertyName = "albums")]
        public AlbumResponse[] AlbumResponses { get; set; }
    }
}

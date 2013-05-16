using Newtonsoft.Json;

namespace SpotifyApi
{
    public class Info
    {
        [JsonProperty(PropertyName = "num_results")]
        public int NumResults { get; set; }

        public int Limit { get; set; }
        public int Offset { get; set; }
        public string Query { get; set; }
        public string Type { get; set; }
        public int Page { get; set; }
    }
}

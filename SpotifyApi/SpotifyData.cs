using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace SpotifyApi
{
    public class SpotifyData
    {
        public string SpotifyAlbumSearchJson(string query)
        {
            return SpotifySearchJson(query, SearchType.Album);
        }

        public string SpotifyArtistSearchJson(string query)
        {
            return SpotifySearchJson(query, SearchType.Artist);
        }

        public string SpotifyTrackSearchJson(string query)
        {
            return SpotifySearchJson(query, SearchType.Track);
        }

        private string SpotifySearchJson(string query, SearchType searchType)
        {
            return LoadJson(MakeSearchJsonUrl(query, searchType));
        }

        public XDocument SpotifyAlbumSearchXml(string query)
        {
            return SpotifySearchXml(query, SearchType.Album);
        }

        public XDocument SpotifyArtistSearchXml(string query)
        {
            return SpotifySearchXml(query, SearchType.Artist);
        }

        public XDocument SpotifyTrackSearchXml(string query)
        {
            return SpotifySearchXml(query, SearchType.Track);
        }

        public string SpotifyArtistLookupJson(string uri, params ArtistExtras[] extras)
        {
            var extrasStrings = extras.Select(e => e.ToString().ToLower());
            return SpotifyLookupJson(uri, extrasStrings.ToArray());
        }

        public string SpotifyAlbumLookupJson(string uri, params AlbumExtras[] extras)
        {
            var extrasStrings = extras.Select(e => e.ToString().ToLower());
            return SpotifyLookupJson(uri, extrasStrings.ToArray());
        }

        public string SpotifyTrackLookupJson(string uri)
        {
            return SpotifyLookupJson(uri);
        }

        private string SpotifyLookupJson(string uri, params string[] extras)
        {
            return LoadJson(MakeLookupJsonUrl(uri, extras));
        }

        private string LoadJson(string url)
        {
            string jsonText = null;

            var httpWebRequest = WebRequest.Create(url);
            var httpWebResponse = httpWebRequest.GetResponse();

            var responseStream = httpWebResponse.GetResponseStream();
            if (responseStream != null)
            {
                using (var streamReader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    jsonText = streamReader.ReadToEnd();
                }
            }

            return jsonText;
        }

        private static string MakeLookupJsonUrl(string uri, string[] extras)
        {
            var extrasBit = extras.Any() ? "&extras=" + string.Join(",", extras) : string.Empty;
            return string.Format("http://ws.spotify.com/lookup/1/.json?uri={0}{1}", uri, extrasBit);
        }

        private XDocument SpotifySearchXml(string query, SearchType searchType)
        {
            return XDocument.Load(MakeSearchXmlUrl(query, searchType));
        }

        private static string MakeSearchJsonUrl(string query, SearchType searchType)
        {
            return MakeSearchUrl(query, searchType, Format.Json);
        }

        private static string MakeSearchXmlUrl(string query, SearchType searchType)
        {
            return MakeSearchUrl(query, searchType, Format.Xml);
        }

        private static string MakeSearchUrl(string query, SearchType searchType, Format format)
        {
            string searchTypeParam = "album";

            switch (searchType)
            {
                case SearchType.Album:
                    searchTypeParam = "album";
                    break;

                case SearchType.Artist:
                    searchTypeParam = "artist";
                    break;

                case SearchType.Track:
                    searchTypeParam = "track";
                    break;
            }

            var formatParam = (format == Format.Json) ? ".json" : string.Empty;

            return string.Format("http://ws.spotify.com/search/1/{0}{1}?q={2}", searchTypeParam, formatParam, query);
        }

        public enum AlbumExtras
        {
            Track,
            TrackDetail
        }

        public enum ArtistExtras
        {
            Album,
            AlbumDetail
        }

        private enum SearchType
        {
            Album,
            Artist,
            Track
        }

        private enum Format
        {
            Xml,
            Json
        }
    }
}

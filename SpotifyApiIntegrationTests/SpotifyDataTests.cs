using NUnit.Framework;
using Newtonsoft.Json;
using SpotifyApi;

namespace SpotifyApiIntegrationTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    internal class SpotifyDataTests
    {
        [Test]
        public void SpotifyAlbumSearchJson_NormalUse_ReturnsSomeJsonData()
        {
            // Arrange
            var spotifyData = new SpotifyData();

            // Act
            var actual = spotifyData.SpotifyAlbumSearchJson("norma+winstone");

            // Assert
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void SpotifyAlbumSearchXml_NormalUse_ReturnsSomeXml()
        {
            // Arrange
            var spotifyData = new SpotifyData();

            // Act
            var actual = spotifyData.SpotifyAlbumSearchXml("norma+winstone");

            // Assert
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void SpotifyAlbumSearchJson_NormalUse_CanDeserialiseObjectGraph()
        {
            // Arrange
            var spotifyData = new SpotifyData();
            var jsonString = spotifyData.SpotifyAlbumSearchJson("norma+winstone");

            // Act
            var actual = JsonConvert.DeserializeObject<AlbumsResponse>(jsonString);

            // Assert
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void SpotifyAlbumLookupJson_NormalUse_ReturnsSomeJsonData()
        {
            // Arrange
            var spotifyData = new SpotifyData();

            // Act
            var actual = spotifyData.SpotifyAlbumLookupJson("spotify:album:4kw074yF3kBfG7U1wqlrnS", SpotifyData.AlbumExtras.Track);

            // Assert
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void SpotifyAlbumLookupJson_NormalUse_CanDeserialiseObjectGraph()
        {
            // Arrange
            var spotifyData = new SpotifyData();
            var jsonString = spotifyData.SpotifyAlbumLookupJson("spotify:album:4kw074yF3kBfG7U1wqlrnS", SpotifyData.AlbumExtras.Track);

            // Act
            var actual = JsonConvert.DeserializeObject<AlbumResponse>(jsonString);

            // Assert
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void SpotifyTrackSearchJson_NormalUse_CanDeserialiseObjectGraph()
        {
            // Arrange
            var spotifyData = new SpotifyData();
            var jsonString = spotifyData.SpotifyTrackSearchJson("A Joyful Noise Unto The Creator");

            // Act
            var actual = JsonConvert.DeserializeObject<TracksResponse>(jsonString);

            // Assert
            Assert.That(actual, Is.Not.Null);
        }
    }
}

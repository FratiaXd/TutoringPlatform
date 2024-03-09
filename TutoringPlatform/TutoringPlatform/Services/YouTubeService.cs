using TutoringPlatform.PrivateInterfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Services
{
    public class YouTubeService : IYouTube
    {
        private readonly HttpClient httpClient;

        public YouTubeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<VideoDetails> GetVideoByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var video = await httpClient.GetAsync($"api/YouTube/Find-Video/{id}");
            var response = await video.Content.ReadFromJsonAsync<List<VideoDetails>>();
            var firstResult = response.FirstOrDefault();
            return firstResult;
        }
    }
}

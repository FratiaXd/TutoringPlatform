using TutoringPlatform.PrivateInterfaces;

namespace TutoringPlatform.Services
{
    public class YouTubeService : IYouTube
    {
        private readonly HttpClient httpClient;

        public YouTubeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


    }
}

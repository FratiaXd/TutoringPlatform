using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.PrivateInterfaces
{
    public interface IYouTube
    {
        Task<VideoDetails> GetVideoByIdAsync(string id);
    }
}

using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TutoringPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YouTubeController : ControllerBase
    {
        [HttpGet("Find-Video/{id}")]
        public async Task<IActionResult> GetChannelVideos(string id)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyAstVHt1yuwBI7ppL5Pim0KLjlOXjFN1Wk",
                ApplicationName = "TutoringPlatform"
            });

            var videoRequest = youtubeService.Videos.List("snippet");
            videoRequest.Id = id;

            var videoResponse = await videoRequest.ExecuteAsync();

            return Ok(videoResponse);
        }
    }
}

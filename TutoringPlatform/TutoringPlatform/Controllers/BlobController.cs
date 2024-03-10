using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoringPlatform.Repositories;
using TutoringPlatform.Shared.Interfaces;

namespace TutoringPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IBlobRepository blobRepository;

        public BlobController(IBlobRepository blobRepository)
        {
            this.blobRepository = blobRepository;
        }

        [HttpPost("UploadBlobFile")]
        public async Task<IActionResult> UploadBlobAsync([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is required.");
            }
            string fileName = file.FileName;
            try
            {
                using (var stream = file.OpenReadStream())
                {
                    var fileUrl = await blobRepository.UploadBlobFileAsync(fileName, stream);
                    return Ok(new { Url = fileUrl });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

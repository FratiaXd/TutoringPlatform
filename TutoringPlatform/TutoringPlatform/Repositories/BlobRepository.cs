using Azure.Storage.Blobs;
using TutoringPlatform.Shared.Interfaces;

namespace TutoringPlatform.Repositories
{
    public class BlobRepository : IBlobRepository
    {
        private readonly BlobServiceClient _blobServiceClient;
        private BlobContainerClient client;

        public BlobRepository(BlobServiceClient blobServiceClient) 
        {
            _blobServiceClient = blobServiceClient;
            client = _blobServiceClient.GetBlobContainerClient("blobcourses");
        }

        public async Task<string> UploadBlobFileAsync(string fileName, Stream content)
        {
            var blobClient = client.GetBlobClient(fileName);
            var status = await blobClient.UploadAsync(content);
            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<bool> DeleteBlobFileAsync(string fileName)
        {
            var blobClient = client.GetBlobClient(fileName);
            var response = await blobClient.DeleteIfExistsAsync();
            return response.Value;
        }
    }
}

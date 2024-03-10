using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringPlatform.Shared.Interfaces
{
    public interface IBlobRepository
    {
        Task<string> UploadBlobFileAsync(string fileName, Stream content);
        Task<bool> DeleteBlobFileAsync(string fileName);
        Task DeleteBlobsByCourseIdAsync(string courseId);
    }
}

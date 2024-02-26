using System.Net.Http.Json;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Client.ApiServices
{
    public class EnrollmentApiService : IEnrollmentService
    {
        private readonly HttpClient httpClient;

        public EnrollmentApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Enrollment> EnrollUserAsync(Enrollment enrollment)
        {
            var newEnrollment = await httpClient.PostAsJsonAsync("api/Enrollment/Enroll-User", enrollment);
            var response = await newEnrollment.Content.ReadFromJsonAsync<Enrollment>();
            return response!;
        }

        public async Task<IEnumerable<Enrollment>> GetAllUserEnrollmentsAsync(string id)
        {
            var enrollments = await httpClient.GetAsync($"api/Enrollment/User-Enrollments/{id}");
            var response = await enrollments.Content.ReadFromJsonAsync<IEnumerable<Enrollment>>();
            return response!;
        }

        public async Task<IEnumerable<Enrollment>> GetUserEnrollmentDataAsync(string id)
        {
            var enrollments = await httpClient.GetAsync($"api/Enrollment/User-Enrollments-Data/{id}");
            var response = await enrollments.Content.ReadFromJsonAsync<IEnumerable<Enrollment>>();
            return response!;
        }

        public async Task<Enrollment> UpdateEnrollmentDetailsAsync(Enrollment enrollment)
        {
            var updEnrollment = await httpClient.PostAsJsonAsync("api/Enrollment/Update-Enrollment", enrollment);
            var response = await updEnrollment.Content.ReadFromJsonAsync<Enrollment>();
            return response!;
        }
    }
}

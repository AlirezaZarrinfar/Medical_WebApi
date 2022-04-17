using Newtonsoft.Json;
using System.Net.Http;

namespace Insurance_WebApi.Application.Services.GetServices
{
    public class GetService : IGetService
    {
        HttpClient _client;
        public GetService()
        {
            _client = new HttpClient();
        }
        public PatientDto GetPatientById(long id)
        {
            string url = "https://localhost:44341/api/Hospital/patient/";
            var result = _client.GetStringAsync(url + id).Result;
            PatientDto patient = JsonConvert.DeserializeObject<PatientDto>(result);
            return patient;
        }
    }
}

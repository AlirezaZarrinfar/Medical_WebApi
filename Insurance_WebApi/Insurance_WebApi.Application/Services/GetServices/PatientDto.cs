using System.Collections.Generic;

namespace Insurance_WebApi.Application.Services.GetServices
{
    public class PatientDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public List<ReceptionDto> Receptions { get; set; }
        public int ReceotionsCount { get; set; }
    }
}

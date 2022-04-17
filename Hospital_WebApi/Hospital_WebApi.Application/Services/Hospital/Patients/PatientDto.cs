using Hospital_WebApi.Application.Services.Hospital.Receptions;
using System.Collections.Generic;

namespace Hospital_WebApi.Application.Services.Hospital.Patients
{
    public class PatientDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public List<ReceptionsDto> Receptions { get; set; }
        public int ReceotionsCount { get; set; }
    }
}   

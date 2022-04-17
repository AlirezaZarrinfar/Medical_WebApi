using System;
using System.Collections.Generic;

namespace Hospital_WebApi.Application.Services.Hospital.Receptions
{
    public class ReceptionsDto
    {
        public long Id { get; set; }
        public DateTime CreateTime { get; set; }
        public long DoctorId { get; set; }
        public long PatientId { get; set; }
        public List<TestGroupsDto> TestGroup { get; set; }
        public double TotalPrice { get; set; }
        public double TotalPriceDiscounted { get; set; }
        public bool IsDiscounted { get; set; }
    }
}

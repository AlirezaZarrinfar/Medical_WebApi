using System.Collections.Generic;

namespace Hospital_WebApi.Application.Services.Hospital.Receptions
{
    public class TestGroupsDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<SubTestsDto> SubTests { get; set; }
        public long ReceptionId { get; set; }
        public double TotalPrice { get; set; }
    }
}

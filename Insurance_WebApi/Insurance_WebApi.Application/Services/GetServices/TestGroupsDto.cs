using System.Collections.Generic;

namespace Insurance_WebApi.Application.Services.GetServices
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

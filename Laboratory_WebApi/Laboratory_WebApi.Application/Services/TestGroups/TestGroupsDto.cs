using Laboratory_WebApi.Application.Services.SubTests;
using System.Collections.Generic;

namespace Laboratory_WebApi.Application.Services.TestGroups
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

using Hospital_WebApi.Application.Services.Hospital.FacadePattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_WebApi.Application.Services.TestGroups
{
    public interface ITestGroupsService
    {
        public List<TestGroupsDto> GetTestGroups();
        public Task<bool> AddTestGroups(TestGroupsDto request);
        public Task<bool> UpdateTestGroups(TestGroupsDto request);
        public Task<bool> DeleteTestGroups(long id);
        public List<TestGroupsDto> GetGroupByParentId(long id);
    }
}

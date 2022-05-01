using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_WebApi.Application.Services.SubTests
{
    public interface ISubTestsService
    {
        public List<SubTestsDto> GetAllSubTests();
        public Task<bool> AddSubTest(SubTestsDto request);
        public Task<bool> DeleteSubTest(long id);
        public Task<bool> UpdateSubTest(SubTestsDto request);
        public List<SubTestsDto> GetSubTestbyParentId(long id);
    }
}

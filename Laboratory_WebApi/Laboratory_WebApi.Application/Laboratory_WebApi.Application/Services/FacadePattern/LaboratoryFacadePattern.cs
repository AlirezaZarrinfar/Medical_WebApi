
using Laboratory_WebApi.Application.Interfaces;
using Laboratory_WebApi.Application.Services.SubTests;
using Laboratory_WebApi.Application.Services.TestGroups;

namespace Hospital_WebApi.Application.Services.Hospital.FacadePattern
{
    public class LaboratoryFacadePattern : ILaboratoryFacadePattern
    {
        private readonly IDatabaseContext _context;
        public LaboratoryFacadePattern(IDatabaseContext context)
        {
            _context = context;
        }
        // Subtest Service
        private ISubTestsService _subTestService;
        public ISubTestsService subTestsService
        {
            get
            {
                return _subTestService = _subTestService ?? new SubTestsService(_context);
            }
        }
        // TestGroup Service
        private ITestGroupsService _testGroupsService;
        public ITestGroupsService testGroupsService
        {
            get
            {
                return _testGroupsService = _testGroupsService ?? new TestGroupsService(_context, subTestsService);
            }
        }
    }
}

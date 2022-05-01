using Laboratory_WebApi.Application.Interfaces;
using Laboratory_WebApi.Application.Services.SubTests;
using Laboratory_WebApi.Domain.Entities.Laboratory;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Laboratory_WebApi.Application.Services.TestGroups
{
    public class TestGroupsService : ITestGroupsService
    {
        private IDatabaseContext _context;
        private ISubTestsService _subTestsService;
        private HttpClient _client;
        public TestGroupsService(IDatabaseContext context, ISubTestsService subTestsService)
        {
            _client = new HttpClient();
            _context = context;
            _subTestsService = subTestsService;
        }
        public void Testgrouplog(string format, string message)
        {
            string url = "https://localhost:44327/api/Logging/Produce?topic=Testgroup&format=" + format + "&message=" + message;
            _client.PostAsync(url, null);
        }
        public async Task<bool> AddTestGroups(TestGroupsDto request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name) || request.ReceptionId == 0)
                {
                    return false;
                }
                TestsGroup testsGroup = new TestsGroup { Id = request.Id, Name = request.Name, ReceptionId = request.ReceptionId };
                await _context.testsGroups.AddAsync(testsGroup);
                await _context.SaveChangesAsync();
                Testgrouplog("Info", "Testgroup added successfully");
                return true;
            }
            catch
            {
                Testgrouplog("Warning", "Testgroup didnt add");
                return false;
            }
        }

        public async Task<bool> DeleteTestGroups(long id)
        {
            try
            {
                if (id == 0)
                {
                    Testgrouplog("Warning", "Testgroup didnt delete");
                    return false;
                }
                var group = await _context.testsGroups.FindAsync(id);
                _context.testsGroups.Remove(group);
                await _context.SaveChangesAsync();
                Testgrouplog("Info", "Testgroup deleted successfully");
                return true;
            }
            catch
            {
                Testgrouplog("Warning", "Testgroup didnt delete");
                return false;
            }
        }

        public List<TestGroupsDto> GetTestGroups()
        {
            var datas = _context.testsGroups.AsQueryable();
            var list = datas.Select(p => new TestGroupsDto { Id = p.Id, Name = p.Name, ReceptionId = p.ReceptionId, }).ToList();
            foreach(var items in list)
            {
                items.SubTests = _subTestsService.GetSubTestbyParentId(items.Id);
                if (items.SubTests != null)
                {
                    items.TotalPrice = 0;
                    for (int i = 0; i < items.SubTests.Count(); i++)
                    {
                        items.TotalPrice += items.SubTests[i].Price;
                    }
                }
            }
            
            return list;
        }

        public async Task<bool> UpdateTestGroups(TestGroupsDto request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name) || request.ReceptionId == 0 || request.Id == 0)
                {
                    Testgrouplog("Warning", "Testgroup didnt update");
                    return false;
                }
                var group = await _context.testsGroups.FindAsync(request.Id);
                group.Name = request.Name;
                group.ReceptionId = request.ReceptionId;
                await _context.SaveChangesAsync();
                Testgrouplog("Info", "Testgroup updated successfully");
                return true;
            }
            catch
            {
                Testgrouplog("Warning", "Testgroup didnt update");
                return false;
            }
        }
        public List<TestGroupsDto> GetGroupByParentId(long id)
        {
            var groups = _context.testsGroups.AsQueryable();
            groups = groups.Where(p => p.ReceptionId == id);
            var list = groups.Select(p => new TestGroupsDto { Id = p.Id, Name = p.Name, ReceptionId = p.ReceptionId, }).ToList();
            foreach (var items in list)
            {
                items.SubTests = _subTestsService.GetSubTestbyParentId(items.Id);
                if (items.SubTests != null)
                {
                    items.TotalPrice = 0;
                    for (int i = 0; i < items.SubTests.Count(); i++)
                    {
                        items.TotalPrice += items.SubTests[i].Price;
                    }
                }
            }
            return list;
        }
    }
}

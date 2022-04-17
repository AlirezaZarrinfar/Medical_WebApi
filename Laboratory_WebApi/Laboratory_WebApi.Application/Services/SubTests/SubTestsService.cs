using Laboratory_WebApi.Application.Interfaces;
using Laboratory_WebApi.Domain.Entities.Laboratory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratory_WebApi.Application.Services.SubTests
{
    public class SubTestsService  : ISubTestsService
    {
        private IDatabaseContext _context;
        public SubTestsService(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> AddSubTest(SubTestsDto request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name) || request.TestsGroupId == 0)
                {
                    return false;
                }

                SubTest subTest = new SubTest { Name = request.Name, Price = request.Price, TestsGroupId = request.TestsGroupId };
                await _context.subTests.AddAsync(subTest);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteSubTest(long id)
        {
            try
            {
                if (id == 0)
                {
                    return false;
                }
                var data = await _context.subTests.FindAsync(id);
                _context.subTests.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<SubTestsDto> GetAllSubTests()
        {
            var datas = _context.subTests.ToList();
            return datas.Select(p => new SubTestsDto { Id = p.Id, Name = p.Name, Price = p.Price, TestsGroupId = p.TestsGroupId }).ToList();
        }

        public List<SubTestsDto> GetSubTestbyParentId(long id)
        {
            var datas = _context.subTests.AsQueryable();
            datas = datas.Where(p => p.TestsGroupId == id);
            return datas.Select(p => new SubTestsDto { Id = p.Id, Name = p.Name, Price = p.Price, TestsGroupId = p.TestsGroupId }).ToList();
        }

        public async Task<bool> UpdateSubTest(SubTestsDto request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name) || request.TestsGroupId == 0 || request.Id == 0)
                {
                    return false;
                }
                var data = await _context.subTests.FindAsync(request.Id);
                data.Name = request.Name;
                data.Price = request.Price;
                data.TestsGroupId = request.TestsGroupId;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

using Hospital_WebApi.Application.Services.Hospital.FacadePattern;
using Laboratory_WebApi.Application.Interfaces;
using Laboratory_WebApi.Application.Services.SubTests;
using Laboratory_WebApi.Application.Services.TestGroups;
using Laboratory_WebApi.Domain.Entities.Laboratory;
using Laboratory_WebApi.Models;
using Laboratory_WebApi.Models.SubTestModels;
using Laboratory_WebApi.Models.TestGroupModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratory_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Laboratory : ControllerBase
    {
        private IDatabaseContext _context;
        private ILaboratoryFacadePattern _laboratoryFacade;
        public Laboratory(IDatabaseContext context, ILaboratoryFacadePattern laboratoryFacade)
        {
            _context = context;
            _laboratoryFacade = laboratoryFacade;
        }
        // SubTestServices
        [HttpGet ("SubTest")]
        public IActionResult GetSubTest()
        {
            var res = _laboratoryFacade.subTestsService.GetAllSubTests();
            return Ok(res);
        }
        [HttpPost("SubTest")]
        public async Task<IActionResult> AddSubTest(SubTestsModelPost model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var res = await _laboratoryFacade.subTestsService.AddSubTest(new SubTestsDto { Name = model.Name, Price = model.Price,TestsGroupId = model.TestsGroupId });
            return Ok(res);
        }
        [HttpPut("SubTest")]
        public async Task<IActionResult> UpdateSubTest(SubTestModelPut model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var res = await _laboratoryFacade.subTestsService.UpdateSubTest(new SubTestsDto { Id = model.Id, Name = model.Name, Price = model.Price ,TestsGroupId = model.TestsGroupId});
            return Ok(res);
        }
        [HttpDelete("SubTest")]
        public async Task<IActionResult> DeleteSubTest(long id)
        {
            var res = await _laboratoryFacade.subTestsService.DeleteSubTest(id);
            return Ok(res);
        }
        [HttpGet("SubTest/{id}")]
        public IActionResult GetSubTestByGroupId(long id)
        {
            var res = _laboratoryFacade.subTestsService.GetSubTestbyParentId(id);
            return Ok(res);
        }

        // TestGroupService
        [HttpGet("TestGroup")]
        public IActionResult GetTestGroup()
        {
            var res = _laboratoryFacade.testGroupsService.GetTestGroups();
            return Ok(res);
        }
        [HttpPost("TestGroup")]
        public async Task<IActionResult> AddTestGroup(TestGroupModelPost model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _laboratoryFacade.testGroupsService.AddTestGroups(new TestGroupsDto { Name = model.Name, ReceptionId = model.ReceptionId });
            return Ok(res);
        }
        [HttpPut("TestGroup")]
        public async Task<IActionResult> UpdateTestGroup(TestGroupModelPut model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var res = await _laboratoryFacade.testGroupsService.UpdateTestGroups(new TestGroupsDto { Id = model.Id, Name = model.Name , ReceptionId = model.ReceptionId });
            return Ok(res);
        }
        [HttpDelete("TestGroup")]
        public async Task<IActionResult> DeleteTestGroup(long id)
        {
            var res = await _laboratoryFacade.testGroupsService.DeleteTestGroups(id);
            return Ok(res);
        }
        [HttpGet("TestGroup/{id}")]
        public IActionResult GetTestGroupByReceptionId(long id)
        {
            var res = _laboratoryFacade.testGroupsService.GetGroupByParentId(id);
            return Ok(res);
        }
    }
}

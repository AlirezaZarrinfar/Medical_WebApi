
using Laboratory_WebApi.Application.Services.SubTests;
using Laboratory_WebApi.Application.Services.TestGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_WebApi.Application.Services.Hospital.FacadePattern
{
    public interface ILaboratoryFacadePattern
    {
        ISubTestsService subTestsService { get; }
        ITestGroupsService testGroupsService { get; }
    }
}

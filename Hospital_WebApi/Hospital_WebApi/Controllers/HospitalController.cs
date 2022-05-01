using Hospital_WebApi.Application.Services.Hospital.FacadePattern;
using Hospital_WebApi.Application.Services.Hospital.Receptions;
using Hospital_WebApi.Models;
using Hospital_WebApi.Models.Hospital;
using Hospital_WebApi.Models.HospitalModels.DoctorModels;
using Hospital_WebApi.Models.HospitalModels.PatientModels;
using Hospital_WebApi.Models.HospitalModels.ReceptionModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hospital_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private IHospitalFacadePattern _hospitalFacade;
        public HospitalController(IHospitalFacadePattern hospitalFacade)
        {
            _hospitalFacade = hospitalFacade;
        }
        //PatientApi
        [HttpGet ("patient")]
        public IActionResult GetPatients()
        {
            var res = _hospitalFacade.patientService.GetPatients();
            return Ok(res);
        }

        [HttpGet("patient/{id}")]
        public IActionResult GetPatientsbyid(long id)
        {
            var res = _hospitalFacade.patientService.GetPatientsById(id);
            return Ok(res);
        }

        [HttpPost("patient")]
        public async Task<IActionResult> PostPatient(PatientModelPost model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _hospitalFacade.patientService.AddPatient(new Patient { Name = model.Name, LastName = model.LastName, NationalCode = model.NationalCode,BirthdayDate = model.BirthdayDate });
            return Ok(res);
        }
        [HttpPut("patient")]
        public async Task<IActionResult> PutPatient(PatientModelPut model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _hospitalFacade.patientService.UpdatePatient(new Patient {Id = model.Id, Name = model.Name, LastName = model.LastName, NationalCode = model.NationalCode , BirthdayDate = model.BirthdayDate });
            return Ok(res);
        
        }
        [HttpDelete("patient")]
        public async Task<IActionResult> DeletePatient(long Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            var res = await _hospitalFacade.patientService.DeletePatient(Id);
            return Ok(res);
        }
        ///////////////////////////////////////////
        //DoctorApi
        [HttpGet("doctor")]
        public IActionResult GetDoctor()
        {
            var res = _hospitalFacade.doctorService.GetDoctor();
            return Ok(res);
        }
        [HttpPost("doctor")]
        public async Task<IActionResult> PostDoctor(DoctorModelPost model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _hospitalFacade.doctorService.AddDoctor(new Doctor { Name = model.Name, LastName = model.LastName, NationalCode = model.NationalCode ,MedicalNumber = model.MedicalNumber});
            return Ok(res);
        }
        [HttpPut("doctor")]
        public async Task<IActionResult> PutDoctor(DoctorModelPut model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _hospitalFacade.doctorService.UpdateDoctor(new Doctor { Id = model.Id, Name = model.Name, LastName = model.LastName, NationalCode = model.NationalCode });
            return Ok(res);
        }
        [HttpDelete("doctor")]
        public async Task<IActionResult> DeleteDoctor(long Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            var res = await _hospitalFacade.doctorService.DeleteDoctor(Id);
            return Ok(res);
        }
        ///////////////////////////////////////////
        //Receptions Api
        [HttpGet("receptions")]
        public IActionResult GetReceptions()
        {
            var res = _hospitalFacade.receptionsService.GetReceptions();
            return Ok(res);
        }
        [HttpPost("receptions")]
        public async Task<IActionResult> PostReceptions(ReceptionModelsPost model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _hospitalFacade.receptionsService.AddReception(new ReceptionsDto {DoctorId = model.DoctorId ,PatientId = model.PatientId });
            return Ok(res);
        }
        [HttpPut("receptions")]
        public async Task<IActionResult> PutReceptions(ReceptionModelsPut model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _hospitalFacade.receptionsService.UpdateReception(new ReceptionsDto { DoctorId = model.DoctorId, PatientId = model.PatientId,Id=model.Id,IsDiscounted = model.IsDiscounted , TotalPriceDiscounted = model.TotalPriceDiscounted  });
            return Ok(res);
        }
        [HttpDelete("receptions")]
        public async Task<IActionResult> DeleteReceptions(long Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            var res = await _hospitalFacade.receptionsService.DeleteReception(Id);
            return Ok(res);
        }
        [HttpGet("receptions/{id}")]
        public IActionResult GetSReceptionByGroupId(long id)
        {
            var res = _hospitalFacade.receptionsService.GetReceptionsByPatientId(id);
            return Ok(res);
        }
    }
}

using Insurance_WebApi.Application.Services.DiscountServices;
using Insurance_WebApi.Application.Services.GetServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Insurance : ControllerBase
    {
        private IGetService _getService;
        private IDiscountService _discountService;
        public Insurance(IGetService getService, IDiscountService discountService)
        {
            _getService = getService;
            _discountService = discountService;
        }
        [HttpGet("Insurance")]
        public IActionResult GetPatient(long id)
        {
            var res = _getService.GetPatientById(id);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult Discount(long PatientId, long ReceptionId)
        {
            var res = _discountService.PutApi(PatientId, ReceptionId);
            return Ok(res);
        }
    }
}

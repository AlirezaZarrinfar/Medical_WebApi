using Logging.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Logging : ControllerBase
    {
        private IKafkaServices _services;
        public Logging(IKafkaServices services)
        {
            _services = services;
        }
        [HttpPost("Produce")]
        public IActionResult Produce(string topic , string format , string message)
        {
            _services.Producer(topic, format, message);
            return Ok();
        }
        [HttpPost("Consume")]
        public IActionResult Consume(string topic)
        {
            _services.Consumer(topic);
            return Ok();
        }
    }
}

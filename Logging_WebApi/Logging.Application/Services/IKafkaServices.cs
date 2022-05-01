using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Application.Services
{
    public interface IKafkaServices
    {
        public Task Producer(string topic, string format, string message);
        public void Consumer(string topic);

    }
}

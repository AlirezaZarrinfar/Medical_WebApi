using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_WebApi.Application.Services.GetServices
{
    public interface IGetService
    {
        PatientDto GetPatientById(long id);
    }
}

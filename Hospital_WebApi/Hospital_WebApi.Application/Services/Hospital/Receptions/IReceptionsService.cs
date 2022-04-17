using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_WebApi.Application.Services.Hospital.Receptions
{
    public interface IReceptionsService
    {
        List<ReceptionsDto> GetReceptions();
        Task<bool> AddReception(ReceptionsDto reception);
        Task<bool> DeleteReception(long Id);
        Task<bool> UpdateReception(ReceptionsDto reception);
        public List<ReceptionsDto> GetReceptionsByPatientId(long id);
    }
}

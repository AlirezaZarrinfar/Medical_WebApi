using Hospital_WebApi.Models.Hospital;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_WebApi.Application.Services.Hospital.Doctors
{
    public interface IDoctorService
    {
        List<DoctorDto> GetDoctor();
        Task<bool> AddDoctor(Doctor doctor);
        Task<bool> DeleteDoctor(long Id);
        Task<bool> UpdateDoctor(Doctor doctor);
    }
}

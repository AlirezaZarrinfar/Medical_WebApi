using Hospital_WebApi.Application.Services.Hospital.Doctors;
using Hospital_WebApi.Application.Services.Hospital.Patients;
using Hospital_WebApi.Application.Services.Hospital.Receptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_WebApi.Application.Services.Hospital.FacadePattern
{
    public interface IHospitalFacadePattern
    {
        IPatientService patientService { get; }
        IDoctorService doctorService { get; }
        IReceptionsService receptionsService { get; }
    }
}

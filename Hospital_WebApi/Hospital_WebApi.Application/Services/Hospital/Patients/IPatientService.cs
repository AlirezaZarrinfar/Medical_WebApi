using Hospital_WebApi.Models.Hospital;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_WebApi.Application.Services.Hospital.Patients
{
    public interface IPatientService
    {
        List<PatientDto> GetPatients();
        Task<bool> AddPatient(Patient patients);
        Task<bool> DeletePatient(long Id);
        Task<bool> UpdatePatient(Patient patients);
        public PatientDto GetPatientsById(long id);
    }
}   

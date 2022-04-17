using Hospital_WebApi.Application.Interfaces.Context;
using Hospital_WebApi.Application.Services.Hospital.Receptions;
using Hospital_WebApi.Models.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_WebApi.Application.Services.Hospital.Patients
{
    public class PatientService : IPatientService
    {
        private IDatabaseContext _context;
        private IReceptionsService _receptions;
        public PatientService(IDatabaseContext context, IReceptionsService receptions)
        {
            _receptions = receptions;
            _context = context;
        }
        public async Task<bool> AddPatient(Patient patients)
        {
            try
            {
                if (string.IsNullOrEmpty(patients.Name) || string.IsNullOrEmpty(patients.LastName) || string.IsNullOrEmpty(patients.NationalCode))
                {
                    return false;
                }
                await _context.Patients.AddAsync(patients);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> DeletePatient(long Id)
        {
            try
            {
                var Patient = await _context.Patients.FindAsync(Id);
                _context.Patients.Remove(Patient);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<PatientDto> GetPatients()
        {
            var Patients = _context.Patients.AsQueryable();
            var list = Patients.Select(p => new PatientDto { Id = p.Id, Name = p.Name, LastName = p.LastName, NationalCode = p.NationalCode }).ToList();
            foreach (var items in list)
            {
                items.Receptions = _receptions.GetReceptionsByPatientId(items.Id);
                if (items.Receptions != null)
                {
                    items.ReceotionsCount = items.Receptions.Count();
                }
            }
            return list;
        }

        public PatientDto GetPatientsById(long id)
        {
            var Patient = _context.Patients.Find(id);
            var patientDto = new PatientDto {Id = Patient.Id, Name = Patient.Name, LastName = Patient.LastName, NationalCode = Patient.NationalCode };
            patientDto.Receptions = _receptions.GetReceptionsByPatientId(Patient.Id);
            if (patientDto.Receptions != null)
            {
                patientDto.ReceotionsCount = patientDto.Receptions.Count();
            }
            return patientDto;
        }

        public async Task<bool> UpdatePatient(Patient patients)
        {
            try
            {
                if (string.IsNullOrEmpty(patients.Name) || string.IsNullOrEmpty(patients.LastName) || string.IsNullOrEmpty(patients.NationalCode) || patients.Id == 0)
                {
                    return false;
                }
                var Patient = await _context.Patients.FindAsync(patients.Id);
                Patient.Name = patients.Name;
                Patient.LastName = patients.LastName;
                Patient.NationalCode = patients.NationalCode;
                patients.BirthdayDate = patients.BirthdayDate;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}   

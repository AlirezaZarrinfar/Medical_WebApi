using Hospital_WebApi.Application.Interfaces.Context;
using Hospital_WebApi.Application.Services.Hospital.Receptions;
using Hospital_WebApi.Models.Hospital;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hospital_WebApi.Application.Services.Hospital.Patients
{
    public class PatientService : IPatientService
    {
        private IDatabaseContext _context;
        private IReceptionsService _receptions;
        private IMemoryCache _cache;
        private HttpClient _client;

        public PatientService(IDatabaseContext context, IReceptionsService receptions,IMemoryCache cache)
        {
            _cache = cache;
            _receptions = receptions;
            _context = context;
            _client = new HttpClient();
        }
        public void Patientlog(string format, string message)
        {
            string url = "https://localhost:44327/api/Logging/Produce?topic=Patient&format=" + format + "&message=" + message;
            _client.PostAsync(url, null);
        }
        public async Task<bool> AddPatient(Patient patients)
        {
            try
            {
                if (string.IsNullOrEmpty(patients.Name) || string.IsNullOrEmpty(patients.LastName) || string.IsNullOrEmpty(patients.NationalCode))
                {
                    Patientlog("Warning", "Patient didnt add");
                    return false;
                }
                await _context.Patients.AddAsync(patients);
                await _context.SaveChangesAsync();
                Patientlog("Info", "Patient added successfully");
                return true;
            }
            catch
            {
                Patientlog("Warning", "Patient didnt add");
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
                Patientlog("Info", "Patient deleted successfully");
                return true;
            }
            catch
            {
                Patientlog("Warning", "Patient didnt delete");
                return false;
            }
        }

        public List<PatientDto> GetPatients()
        {
            var Patients = _context.Patients.AsQueryable();
            var list = Patients.Select(p => new PatientDto { Id = p.Id, Name = p.Name, LastName = p.LastName, NationalCode = p.NationalCode , BirthdayDate = p.BirthdayDate}).ToList();
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
            var patientcache = _cache.Get<PatientDto>(id);
            if (patientcache != null)
            {
                return patientcache;
            }
            else
            {
                var Patient = _context.Patients.Find(id);
                var patientDto = new PatientDto { Id = Patient.Id, Name = Patient.Name, LastName = Patient.LastName, NationalCode = Patient.NationalCode, BirthdayDate = Patient.BirthdayDate };
                patientDto.Receptions = _receptions.GetReceptionsByPatientId(Patient.Id);
                if (patientDto.Receptions != null)
                {
                    patientDto.ReceotionsCount = patientDto.Receptions.Count();
                }
                var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(120));
                _cache.Set(patientDto.Id, patientDto, options);
                return patientDto;
            }
        }

        public async Task<bool> UpdatePatient(Patient patients)
        {
            try
            {
                if (string.IsNullOrEmpty(patients.Name) || string.IsNullOrEmpty(patients.LastName) || string.IsNullOrEmpty(patients.NationalCode) || patients.Id == 0)
                {
                    Patientlog("Warning", "Patient didn't update");
                    return false;
                }
                var Patient = await _context.Patients.FindAsync(patients.Id);
                Patient.Name = patients.Name;
                Patient.LastName = patients.LastName;
                Patient.NationalCode = patients.NationalCode;
                Patient.BirthdayDate = patients.BirthdayDate;
                await _context.SaveChangesAsync();
                Patientlog("Info", "Patient updated successfully");
                return true;
            }
            catch
            {
                Patientlog("Warning", "Patient didn't update");
                return false;
            }
        }

    }
}   

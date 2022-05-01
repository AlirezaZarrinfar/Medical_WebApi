using Hospital_WebApi.Application.Interfaces.Context;
using Hospital_WebApi.Models.Hospital;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hospital_WebApi.Application.Services.Hospital.Doctors
{
    public class DoctorService : IDoctorService
    {
        private IDatabaseContext _context;
        private HttpClient _client;
        public DoctorService(IDatabaseContext context)
        {
            _context = context;
            _client = new HttpClient();
        }
        public void doctorlog (string format, string message)
        {
            string url = "https://localhost:44327/api/Logging/Produce?topic=Doctor&format=" + format + "&message=" + message;
             _client.PostAsync(url, null);
        }
        public async Task<bool> AddDoctor(Doctor doctor)
        {
            try
            {
                if (string.IsNullOrEmpty(doctor.Name) || string.IsNullOrEmpty(doctor.LastName) || string.IsNullOrEmpty(doctor.NationalCode) || string.IsNullOrEmpty(doctor.MedicalNumber))
                {
                    doctorlog("Warning", "Doctor didnt add");
                    return false;
                }
                await _context.Doctors.AddAsync(doctor);
                await _context.SaveChangesAsync();
                doctorlog("Info", "Doctor added successfully");
                return true;
            }
            catch
            {
                doctorlog("Warning", "Doctor didnt add");
                return false;
            }
        }

        public async Task<bool> DeleteDoctor(long Id)
        {
            try
            {
                var Doctor = await _context.Doctors.FindAsync(Id);
                _context.Doctors.Remove(Doctor);
                await _context.SaveChangesAsync();
                doctorlog("Info", "Doctor deleted successfully");
                return true;
            }
            catch
            {
                doctorlog("Warning", "Doctor didnt delete");
                return false;
            }
        }

        public List<DoctorDto> GetDoctor()
        {
            var Doctors = _context.Doctors.AsQueryable();
            return Doctors.Select(p => new DoctorDto { Id = p.Id, Name = p.Name, LastName = p.LastName, NationalCode = p.NationalCode ,MedicalNumber = p.MedicalNumber}).ToList();
        }

        public async Task<bool> UpdateDoctor(Doctor doctor)
        {
            try
            {
                if (string.IsNullOrEmpty(doctor.Name) || string.IsNullOrEmpty(doctor.LastName) || string.IsNullOrEmpty(doctor.NationalCode) || string.IsNullOrEmpty(doctor.MedicalNumber) || doctor.Id == 0)
                {
                    doctorlog("Warning", "Doctor didn't update");
                    return false;
                }
                var Doctor = await _context.Doctors.FindAsync(doctor.Id);
                Doctor.Name = doctor.Name;
                Doctor.LastName = doctor.LastName;
                Doctor.NationalCode = doctor.NationalCode;
                Doctor.MedicalNumber = doctor.MedicalNumber;
                await _context.SaveChangesAsync();
                doctorlog("Info", "Doctor updated successfully");
                return true;
            }
            catch
            {
                doctorlog("Warning", "Doctor didn't update");
                return false;
            }
        }
    }
}

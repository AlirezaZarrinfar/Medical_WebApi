using Hospital_WebApi.Application.Interfaces.Context;
using Hospital_WebApi.Models.Hospital;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_WebApi.Application.Services.Hospital.Doctors
{
    public class DoctorService : IDoctorService
    {
        private IDatabaseContext _context;
        public DoctorService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> AddDoctor(Doctor doctor)
        {
            try
            {
                if (string.IsNullOrEmpty(doctor.Name) || string.IsNullOrEmpty(doctor.LastName) || string.IsNullOrEmpty(doctor.NationalCode) || string.IsNullOrEmpty(doctor.MedicalNumber))
                {
                    return false;
                }
                await _context.Doctors.AddAsync(doctor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
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
                return true;
            }
            catch
            {
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
                    return false;
                }
                var Doctor = await _context.Doctors.FindAsync(doctor.Id);
                Doctor.Name = doctor.Name;
                Doctor.LastName = doctor.LastName;
                Doctor.NationalCode = doctor.NationalCode;
                Doctor.MedicalNumber = doctor.MedicalNumber;
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

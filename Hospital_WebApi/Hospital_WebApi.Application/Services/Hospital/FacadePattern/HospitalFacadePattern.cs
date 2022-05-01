using Hospital_WebApi.Application.Interfaces.Context;
using Hospital_WebApi.Application.Services.Hospital.Doctors;
using Hospital_WebApi.Application.Services.Hospital.Patients;
using Hospital_WebApi.Application.Services.Hospital.Receptions;
using Microsoft.Extensions.Caching.Memory;

namespace Hospital_WebApi.Application.Services.Hospital.FacadePattern
{
    public class HospitalFacadePattern : IHospitalFacadePattern
    {
        private readonly IDatabaseContext _context;
        private IMemoryCache _cache;

        public HospitalFacadePattern(IDatabaseContext context, IMemoryCache cache)
        {
            _cache = cache;
            _context = context;

        }
        // PatientService
        private IPatientService _patientService;
        public IPatientService patientService
        {
            get
            {
                return _patientService = _patientService ?? new PatientService(_context, receptionsService,_cache);
            }
        }
        // DoctorService
        private IDoctorService _doctorService;
        public IDoctorService doctorService
        {
            get
            {
                return _doctorService = _doctorService ?? new DoctorService(_context);
            }
        }
        // ReceptionsService
        private IReceptionsService _receptionsService;
        public IReceptionsService receptionsService
        {
            get
            {
                return _receptionsService = _receptionsService ?? new ReceptionsService(_context);
            }
        }
    }
}

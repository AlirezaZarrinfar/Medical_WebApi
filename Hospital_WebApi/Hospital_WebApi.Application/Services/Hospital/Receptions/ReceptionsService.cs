using Hospital_WebApi.Application.Interfaces.Context;
using Hospital_WebApi.Models.Hospital;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hospital_WebApi.Application.Services.Hospital.Receptions
{
    public class ReceptionsService : IReceptionsService
    {
        private HttpClient _client;
        private IDatabaseContext _context;
        public ReceptionsService(IDatabaseContext context)
        {
            _client = new HttpClient();
            _context = context;
        }
        public async Task<bool> AddReception(ReceptionsDto reception)
        {
            try
            {
                Reception rec = new Reception()
                {
                    DoctorId = reception.DoctorId,
                    PatientId = reception.PatientId,
                    CreateTime = DateTime.Now,
                    IsDiscounted = false,
                    TotalPriceDiscounted = 0,
                };
                await _context.Receptions.AddAsync(rec);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteReception(long Id)
        {
            try
            {
                var Receptions = await _context.Receptions.FindAsync(Id);
                _context.Receptions.Remove(Receptions);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<TestGroupsDto> GetGroups(long id)
        {
            try
            {
                string url = "https://localhost:44327/api/laboratory/testgroup/";
                var result = _client.GetStringAsync(url + id).Result;
                List<TestGroupsDto> Groups = JsonConvert.DeserializeObject<List<TestGroupsDto>>(result);
                return Groups;
            }
            catch
            {
                return null;
            }
        }
        public List<ReceptionsDto> GetReceptions()
        {
            var Receptions = _context.Receptions.AsQueryable();
            var data = Receptions.Select(p => new ReceptionsDto { PatientId = p.PatientId , DoctorId = p.DoctorId , Id = p.Id,CreateTime = p.CreateTime,IsDiscounted = p.IsDiscounted , TotalPriceDiscounted = p.TotalPriceDiscounted  }).ToList();
            foreach(var items in data)
            {
                items.TestGroup = GetGroups(items.Id);
                if (items.TestGroup != null)
                {
                    items.TotalPrice = 0;
                    for (int i = 0; i < items.TestGroup.Count(); i++)
                    {
                        items.TotalPrice += items.TestGroup[i].TotalPrice;
                    }
                }
            }
            return data;
        }

        public async Task<bool> UpdateReception(ReceptionsDto reception)
        {
            try
            {
                if (reception.PatientId==0 || reception.Id==0 || reception.DoctorId == 0)
                {
                    return false;
                }
                var rec = await _context.Receptions.FindAsync(reception.Id);
                rec.DoctorId = reception.DoctorId;
                rec.PatientId = reception.PatientId;
                rec.IsDiscounted = reception.IsDiscounted;
                rec.TotalPriceDiscounted = reception.TotalPriceDiscounted;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ReceptionsDto> GetReceptionsByPatientId(long id)
        {
            var Receptions = _context.Receptions.AsQueryable();
            Receptions = Receptions.Where(p => p.PatientId == id);
            var data = Receptions.Select(p => new ReceptionsDto { PatientId = p.PatientId, DoctorId = p.DoctorId, Id = p.Id, CreateTime = p.CreateTime , IsDiscounted = p.IsDiscounted , TotalPriceDiscounted = p.TotalPriceDiscounted}).ToList();
            foreach (var items in data)
            {
                items.TestGroup = GetGroups(items.Id);
                if (items.TestGroup != null)
                {
                    items.TotalPrice = 0;
                    for (int i = 0; i < items.TestGroup.Count(); i++)
                    {
                        items.TotalPrice += items.TestGroup[i].TotalPrice;
                    }
                }
            }
            return data;
        }
    }
}

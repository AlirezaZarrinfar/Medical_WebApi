using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance_WebApi.Application.Services.DiscountServices
{
    public interface IDiscountService
    {
        public bool PutApi(long PatientId, long ReceptionId);
        public double Discount(double Price, int ReceptionsNumber);
    }


}

using Insurance_WebApi.Application.Services.GetServices;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Insurance_WebApi.Application.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        IGetService _getService;
        HttpClient _client;
        public DiscountService(IGetService getService)
        {
            _getService = getService;
            _client = new HttpClient();
        }

        public void Discountlog(string format, string message)
        {
            string url = "https://localhost:44327/api/Logging/Produce?topic=Discounts&format=" + format + "&message=" + message;
            _client.PostAsync(url, null);
        }


        public bool PutApi(long PatientId , long ReceptionId)
        {
            try
            {
                string url = "https://localhost:44341/api/Hospital/receptions/";
                var patient = _getService.GetPatientById(PatientId);
                var reception = patient.Receptions.FirstOrDefault(p => p.Id == ReceptionId);
                reception.IsDiscounted = true;
                reception.TotalPriceDiscounted = Discount(reception.TotalPrice, patient.ReceotionsCount);
                string jsonCustomer = JsonConvert.SerializeObject(reception);
                StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");
                var res = _client.PutAsync(url, content).Result;
                Discountlog("Info", $"Reception {ReceptionId} Discounted Successfully");
                return true;
            }
            catch
            {
                Discountlog("Warning", $"Reception {ReceptionId} didnt Discounted");
                return false;
            }
        }
        public double Discount(double Price , int ReceptionsNumber)
        {
            if (1 <= ReceptionsNumber || ReceptionsNumber < 4)
            {
                Price = Price - ((Price / 100) * 10);
            }
            else if (4 <= ReceptionsNumber || ReceptionsNumber < 11)
            {
                Price = Price - ((Price / 100) * 20);
            }
            else if (11 <= ReceptionsNumber || ReceptionsNumber < 50)
            {
                Price = Price - ((Price / 100) * 50);
            }
            return Price;
        }
    }


}

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BookStoreApp.Models;

namespace BookStoreApp.Services
{
    public interface IAdService
    {
        bool AddAd(Ad ad);
        List<Ad> GetAllAds();
        bool DeleteAd(int id);
    }
    public class AdService : IAdService
    {
        private readonly HttpClient _httpClient;
            public AdService(HttpClient httpClient,IConfiguration configuration)
        {
HttpClientHandler clientHandler = new HttpClientHandler();
clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
_httpClient=new HttpClient(clientHandler);
         var apiSettings = configuration.GetSection("ApiSettings").Get<ApiSettings>();
        _httpClient.BaseAddress =new Uri(apiSettings.BaseUrl) ;
        }

        public bool AddAd(Ad ad)
        {
            try
            {
                var json = JsonConvert.SerializeObject(ad);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress+$"/Ad", content).Result;

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        public List<Ad> GetAllAds()
        {
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress+"/Ad").Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Ad>>(data);
                }

                return new List<Ad>();
            }
            catch (HttpRequestException)
            {
                return new List<Ad>();
            }
        }

        public bool DeleteAd(int id)
        {
            try
            {
                HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress+$"/Ad/{id}").Result;

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}

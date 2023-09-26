using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BookStoreApp.Models;

namespace BookStoreApp.Services
{
    public interface IChannelService
    {
        bool AddChannel(Channel channel);
        List<Channel> GetAllChannels();
        bool DeleteChannel(int id);
        Task<IEnumerable<string>> GetChannelNames();
    }
    public class ChannelService : IChannelService
    {
        private readonly HttpClient _httpClient;
        public ChannelService(HttpClient httpClient, IConfiguration configuration)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = new HttpClient(clientHandler);
            var apiSettings = configuration.GetSection("ApiSettings").Get<ApiSettings>();
            _httpClient.BaseAddress = new Uri(apiSettings.BaseUrl);
        }

        public bool AddChannel(Channel channel)
        {
            try
            {
                var json = JsonConvert.SerializeObject(channel);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + $"/Channel", content).Result;

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
       public async Task<IEnumerable<string>> GetChannelNames()
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Channel/ChannelTitle");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<string>>(data);
            }

            return new List<string>();
        }
        catch (HttpRequestException)
        {
            return new List<string>();
        }
    }
        public List<Channel> GetAllChannels()
        {
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Channel").Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Channel>>(data);
                }

                return new List<Channel>();
            }
            catch (HttpRequestException)
            {
                return new List<Channel>();
            }
        }


        public bool DeleteChannel(int id)
        {
            try
            {
                HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + $"/Channel/{id}").Result;

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}

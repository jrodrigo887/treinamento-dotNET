using Aula3.Interfaces;
using Aula3.models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace Aula3.Services
{
    public class PrevisaoService: IPrevisaoService
    {
        static readonly HttpClient client = new HttpClient();
        static readonly string Url = "https://api.hgbrasil.com/";
        private static string apiKey; 
        private IConfiguration conf { get; }

        public PrevisaoService(IConfiguration configuration)
        {
            conf = configuration;
            apiKey = conf["HG:apiKey"];
        }

        public string GetCurrentTimeNow()
        {
            var obj = $"India,\n{DateTime.Now.ToLongDateString()}\n{DateTime.Now.ToString("dd/MM/yyyy - HH:mm")}";
            return obj;
        }

        public async Task<WeatherForecastDetail> GetMyTimeAsync()
        {
            WeatherForecastDetail weatherForecast;

            string enginerName = Dns.GetHostName();
            IPAddress[] enginerIp = Dns.GetHostAddresses(enginerName);
            var myIp = enginerIp[1].MapToIPv4().ToString();

            if (myIp == null)
            {
                myIp = "remote";
            }

            try
            {
                HttpResponseMessage response = 
                    await client.GetAsync($"{Url}weather?key={apiKey}&user_ip={myIp}");

                response.EnsureSuccessStatusCode();
                
                var responseString = await response.Content.ReadAsStringAsync();

                weatherForecast = ConvertStringToJson<WeatherForecastDetail>(responseString);

                return weatherForecast;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                throw;
            }
        }

        public async Task<WeatherForecastDetail> GetTimeMyCityAsync(string City, string State)
        {
            WeatherForecastDetail weatherForecast;
            string city = City, state = State;

            if (city == null && state == null)
            {
                city = "Sao Paulo";
                state = "SP";
            }

            try
            {
                HttpResponseMessage response =
                    await client.GetAsync($"{Url}weather?key={apiKey}&city_name={city},{state.ToUpper()}");

                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);

                weatherForecast = ConvertStringToJson<WeatherForecastDetail>(responseString);

                return weatherForecast;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                throw;
            }
        }

        T ConvertStringToJson<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
    
}

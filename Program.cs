using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace DataFromCountryAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://localhost:59030/api/country/");
            client.Timeout = -1;
            
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(response.Content);
            foreach (Country country in countries)
            {
                Console.WriteLine($"{country.Population2017} - {country.CountryName}");
            }
            
            Console.ReadLine();
        }
    }
}

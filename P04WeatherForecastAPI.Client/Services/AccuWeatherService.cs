using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    internal class AccuWeatherService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language{2}";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language{2}";

        private const string historical_conditions_past_24h_endpoint = "currentconditions/v1/{0}/historical/24?apikey={1}&language{2}";
        private const string forecast_12_hours_endpoint = "forecasts/v1/hourly/12hour/{0}?apikey={1}&language{2}&metric=true";
        private const string forecast_1_hour_endpoint = "forecasts/v1/hourly/1hour/{0}?apikey={1}&language{2}&metric=true";

        private const string get_regions_endpoint = "locations/v1/regions?apikey={0}&language{1}";
        private const string get_country_list_endpoint = "locations/v1/countries/{0}?apikey={1}&language{2}";

        // private const string api_key = "5hFl75dja3ZuKSLpXFxUzSc9vXdtnwG5";
        string api_key;
        //private const string language = "pl";
        string language;

        public AccuWeatherService()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json"); 

            var configuration = builder.Build();
            api_key = configuration["api_key"];
            language = configuration["default_language"];
        }


        public async Task<City[]> GetLocations(string locationName)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;

            }
        }

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key,language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers= JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers.FirstOrDefault();
            }
        }

        // ---

        public async Task<Weather> GetHistoricalCurrentConditionsPast24Hours(string cityKey)
        {
            string uri = base_url + "/" + string.Format(historical_conditions_past_24h_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers = JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers.FirstOrDefault();
            }
        }

        public async Task<HourWeather[]> Get12HoursOfHourlyForecats(string cityKey)
        {
            string uri = base_url + "/" + string.Format(forecast_12_hours_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                HourWeather[] weathers = JsonConvert.DeserializeObject<HourWeather[]>(json);
                return weathers;
            }
        }

        public async Task<HourWeather> Get1HourOfHourlyForecats(string cityKey)
        {
            string uri = base_url + "/" + string.Format(forecast_1_hour_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                HourWeather[] weathers = JsonConvert.DeserializeObject<HourWeather[]>(json);
                return weathers.FirstOrDefault();
            }
        }




        public async Task<Region[]> GetRegions()
        {
            string uri = base_url + "/" + string.Format(get_regions_endpoint, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Region[] regions = JsonConvert.DeserializeObject<Region[]>(json);
                return regions;
            }
        }

        public async Task<Region[]> GetCountryList(string regionKey)
        {
            string uri = base_url + "/" + string.Format(get_country_list_endpoint, regionKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Region[] regions = JsonConvert.DeserializeObject<Region[]>(json);
                return regions;
            }
        }

    }
}

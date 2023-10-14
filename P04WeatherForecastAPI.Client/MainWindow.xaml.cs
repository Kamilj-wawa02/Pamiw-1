using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P04WeatherForecastAPI.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccuWeatherService accuWeatherService;
        public MainWindow()
        {
            InitializeComponent();
            accuWeatherService = new AccuWeatherService();
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            City[] cities= await accuWeatherService.GetLocations(txtCity.Text);

            // standardowy sposób dodawania elementów
            //lbData.Items.Clear();
            //foreach (var c in cities)
            //    lbData.Items.Add(c.LocalizedName);

            // teraz musimy skorzystac z bindowania danych bo chcemy w naszej kontrolce przechowywac takze id miasta 
            lbCities.ItemsSource = cities;
        }

        private async void btnSearchRegions_Click(object sender, RoutedEventArgs e)
        {
            Region[] regions = await accuWeatherService.GetRegions();
            lbRegions.ItemsSource = regions;
        }

        private async void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCity = (City) lbCities.SelectedItem;
            if(selectedCity != null)
            {
                var weather = await accuWeatherService.GetCurrentConditions(selectedCity.Key);
                lblCityName.Content = selectedCity.LocalizedName;
                double tempValue = weather.Temperature.Metric.Value;
                lblTemperatureValue.Content = Convert.ToString(tempValue);

                var weather_Past24h = await accuWeatherService.GetHistoricalCurrentConditionsPast24Hours(selectedCity.Key);
                double tempYesterdayValue = weather_Past24h.Temperature.Metric.Value;
                lblTemperatureYesterdayValue.Content = Convert.ToString(tempYesterdayValue);

                var weather_1hour = await accuWeatherService.Get1HourOfHourlyForecats(selectedCity.Key);
                double temp1hourValue = weather_1hour.Temperature.Value;
                lblTemperatureIn1HourValue.Content = Convert.ToString(temp1hourValue);

                HourWeather[] forecats_12Hours = await accuWeatherService.Get12HoursOfHourlyForecats(selectedCity.Key);
                String[] temperatures = new string[forecats_12Hours.Length];
                for (int i = 0; i < forecats_12Hours.Length; i++)
                {
                    if (forecats_12Hours[i] != null)
                    {
                        temperatures[i] = "at " + forecats_12Hours[i].DateTime.Hour + " will be: " + forecats_12Hours[i].Temperature.Value;
                    }
                }
                lbHourlyTemperatures.ItemsSource = temperatures;
            }
        }

        private async void lbRegions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRegion = (Region) lbRegions.SelectedItem;
            if (selectedRegion != null)
            {
                Region[] countries = await accuWeatherService.GetCountryList(selectedRegion.ID);
                lbCountries.ItemsSource = countries;
            }
        }


    }
}

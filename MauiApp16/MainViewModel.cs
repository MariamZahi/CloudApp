using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

public class MainViewModel : BindableObject
{
    private string _city;
    private string _weatherInfo;

    public string City
    {
        get => _city;
        set
        {
            _city = value;
            OnPropertyChanged(nameof(City));
        }
    }

    public string WeatherInfo
    {
        get => _weatherInfo;
        set
        {
            _weatherInfo = value;
            OnPropertyChanged(nameof(WeatherInfo));
        }
    }

    public ICommand GetWeatherCommand => new Command(async () => await GetWeather());

    public Task WeatherCommand { get; internal set; }

    private async Task GetWeather()
    {
        // Added API KEY and API ENDPOINT for location that i found in documentation
        // Using weatherbit.io
        string apiKey = "d8233951efaa408daa6626fac1913d86";
        string apiEndpoint = "https://api.weatherbit.io/v2.0/forecast/hourly";
        double lat = 47.61;
        double lon = -122.33;
        string city = "Seattle";
        DateTime start_date = new DateTime(2020,8,12);
        DateTime end_date = new DateTime(2021, 3, 1);
        string apiUrl = $"{apiEndpoint}?lat={lat}&lon={lon}&city={city}&start_date={start_date}&end_date={end_date}&key={apiKey}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                // Parse the weather data and update WeatherInfo property.
                // Implement this based on the actual response structure of my weatherbit API.
                WeatherInfo = ParseWeatherData(data);
            }
            else
            {
                WeatherInfo = "Error fetching weather data.";
            }
        }
    }

    private string ParseWeatherData(string data)
    {
        // Implement the parsing logic based on your weather API response format.
        // Update this method accordingly.
        // This is just a placeholder.
        return $"Weather data for {City}: {data}";
    }
}
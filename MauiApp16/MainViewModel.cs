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

    internal Task WeatherCommand => throw new NotImplementedException();

    private async Task GetWeather()
    {
        // Added API KEY and API ENDPOINT for location that i found in documentation
        // Using weatherbit.io
        string apiKey = "d8233951efaa408daa6626fac1913d86";
        string apiEndpoint = "https://api.weatherbit.io/v2.0/forecast/hourly";
        string city = "Toronto";
        int hours = 48;
        string apiUrl = $"{apiEndpoint}?city={city}&hours={hours}&key={apiKey}";

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
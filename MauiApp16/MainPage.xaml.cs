using Microsoft.Maui.Controls;

namespace MauiApp16
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnPredictClicked(object sender, EventArgs e)
        {
            string selectedDisease = diseasePicker.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedDisease))
            {
                DisplayAlert("Error", "Please select a condition", "OK");
                return;
            }

            string prediction = PredictWeather(selectedDisease);
            predictionLabel.Text = $"Likely weather conditions for {selectedDisease}: {prediction}";
        }

        private string PredictWeather(string disease)
        {
            // Simple mapping for demonstration purposes
            switch (disease.ToLower())
            {
                case "flu":
                    return "Cold weather, winter months";
                case "cough":
                    return "Cold or dry weather";
                case "fever":
                    return "Hot weather, summer months";
                case "nausea":
                    return "Hot weather, summer months";
                case "headache":
                    return "Weather changes, low pressure";
                case "bleeding":
                    return "No specific weather correlation";
                default:
                    return "No prediction available";
            }
        }
    }
}

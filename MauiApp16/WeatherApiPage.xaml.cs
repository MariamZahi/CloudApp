using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Maui.Controls;

namespace MauiApp16
{
    public partial class WeatherApiPage : ContentPage
    {
        private MainViewModel _viewModel;

        public WeatherApiPage()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            BindingContext = _viewModel;
        }

        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            await _viewModel.WeatherCommand;
            weatherInfoLabel.Text = _viewModel.WeatherInfo;
        }
    }
}

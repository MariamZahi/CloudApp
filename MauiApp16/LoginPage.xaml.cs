using Microsoft.Maui.Controls;

namespace MauiApp16
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            // Add your authentication logic here
            if (IsValidUser(username, password))
            {
                // Navigate to the main page or perform necessary actions
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }
        }

        private bool IsValidUser(string username, string password)
        {
            // Replace this with your actual authentication logic
            return username == "user" && password == "password";
        }
    }
}

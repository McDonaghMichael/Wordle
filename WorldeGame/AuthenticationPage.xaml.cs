using Microsoft.Maui.Controls;

namespace WorldeGame
{
    public partial class AuthenticationPage : ContentPage
    {
        private Entry UsernameEntry;
        private Entry PasswordEntry;
        private Button LoginButton;

        public AuthenticationPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromArgb(DefaultConstants.GetBackgroundColor());

            CreateUI();

            LoginButton.Clicked += LoginButtonClicked;
        }

        private void CreateUI()
        {
            Label headerLabel = new Label
            {
                Text = "Login",
                FontSize = 30,
                TextColor = Colors.White,
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 20)
            };

            UsernameEntry = new Entry
            {
                Placeholder = "Username",
                HorizontalOptions = LayoutOptions.Center,
                PlaceholderColor = Colors.LightGray,
                WidthRequest = 240,
                Margin = new Thickness(0, 0, 0, 10),
                FontSize = 16
            };

            PasswordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true,
                HorizontalOptions = LayoutOptions.Center,
                PlaceholderColor = Colors.LightGray,
                WidthRequest = 240,
                Margin = new Thickness(0, 0, 0, 20),
                FontSize = 16
            };

            LoginButton = new Button
            {
                Text = "Login",
                TextColor = Colors.White,
                BackgroundColor = Color.FromArgb(DefaultConstants.GetButtonBackgroundColor(1)),
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 120,
                Margin = new Thickness(0, 0, 0, 0)
            };

            Content = new VerticalStackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = { headerLabel, UsernameEntry, PasswordEntry, LoginButton }
            };
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

           
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
               
                await DisplayAlert("Login Error", "Invalid username or password.", "OK");
            }
        }
    }
}

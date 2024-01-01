namespace WorldeGame
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPlayButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the PreGamePage when the Play button is clicked
             await Navigation.PushAsync(new GamePage());
        }

    }
}
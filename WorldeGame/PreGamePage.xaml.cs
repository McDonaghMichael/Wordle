
namespace WorldeGame
{
    public partial class PreGamePage : ContentPage
    {
        Entry gamertagEntry; // Declare gamertagEntry as a class-level variable

        public PreGamePage()
        {
            InitializeComponent();

            if (Preferences.ContainsKey("Gamertag"))
            {
                // Gamertag is saved, load a different layout
                LoadExistingGamertagLayout();
            }
        }

        private void LoadExistingGamertagLayout()
        {
            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var label = new Label
            {
                Text = $"Current Gamertag: {Preferences.Get("Gamertag", string.Empty)}",
                Margin = new Thickness(0, 0, 0, 20)
            };

            var changeButton = new Button
            {
                Text = "Change Gamertag"
            };
            changeButton.Clicked += OnChangeGamertagClicked;

            var continueButton = new Button
            {
                Text = "Continue"
            };
            continueButton.Clicked += OnContinueClicked;

            stackLayout.Children.Add(label);
            stackLayout.Children.Add(changeButton);
            stackLayout.Children.Add(continueButton);

            Content = stackLayout;
        }

        private async void OnChangeGamertagClicked(object sender, EventArgs e)
        {
            // Prompt the user to change the gamertag
            string newGamertag = await DisplayPromptAsync("Change Gamertag", "Enter a new gamertag:");

            // Save the new gamertag to preferences
            Preferences.Set("Gamertag", newGamertag);

            UpdateLabelWithGamertag(newGamertag);

            // Navigate to a different page or perform other actions if needed
            // For example: Navigation.PushAsync(new AnotherPage());
        }

        private void OnContinueClicked(object sender, EventArgs e)
        {
            // Continue to a different page or perform other actions if needed
            // For example: Navigation.PushAsync(new AnotherPage());
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            // Save the entered gamertag to preferences
            string gamertag = gamertagEntry.Text;
            Preferences.Set("Gamertag", gamertag);

            // Perform other actions if needed
        }

        private void UpdateLabelWithGamertag(string gamertag)
        {
            if (Content is StackLayout stackLayout)
            {
                foreach (var child in stackLayout.Children)
                {
                    if (child is Label label && label.Text.StartsWith("Current Gamertag:"))
                    {
                        label.Text = $"Current Gamertag: {gamertag}";
                        break;
                    }
                }
            }
        }
    }
}

namespace WorldeGame
{
    public partial class SettingsPage : ContentPage
    {
        Switch darkModeSwitch;
        Slider fontSizeSlider;
        Switch hintsToggle;

        public SettingsPage()
        {
            InitializeComponent();
            CreateUI();
            ApplyDefaultSettings();
        }

        private void CreateUI()
        {
            this.BackgroundColor = Color.FromArgb(DefaultConstants.GetBackgroundColor());

            darkModeSwitch = CreateSwitch();
            layout.Children.Add(CreateLabel("Dark Mode"));
            layout.Children.Add(darkModeSwitch);

            hintsToggle = CreateSwitch();
            layout.Children.Add(CreateLabel("Hints"));
            layout.Children.Add(hintsToggle);

            fontSizeSlider = new Slider
            {
                Minimum = 10,
                Maximum = 52,
                Value = 20,
            };
            layout.Children.Add(CreateLabel("Font Size"));
            layout.Children.Add(fontSizeSlider);
            layout.Children.Add(CreateLabel(fontSizeSlider.Value.ToString()));

            layout.Children.Add(CreateStyledButton("Save", OnSaveButtonClicked, 1));
            layout.Children.Add(CreateStyledButton("Reset to Defaults", OnResetButtonClicked, 1));
            layout.Children.Add(CreateStyledButton("Save and Exit", OnSaveAndExitButtonClicked, 2));
            layout.Children.Add(CreateStyledButton("Exit without saving", ExitWithoutSavingButtonClicked, 1));
        }

        private static Switch CreateSwitch()
        {
            return new Switch {};
        }

        private static Label CreateLabel(string text)
        {
            return new Label
            {
                Text = text
            };
        }

        private static Button CreateStyledButton(string text, EventHandler handler, int buttonType)
        {
            var button = new Button
            {
                Text = text,
                BackgroundColor = Color.FromArgb(DefaultConstants.GetButtonBackgroundColor(buttonType)),
                TextColor = Colors.White,
                FontSize = 20,
                HeightRequest = 60,
                WidthRequest = 250,
                CornerRadius = 10,
                Margin = 5,
                HorizontalOptions = LayoutOptions.Center
            };

            if (handler != null)
            {
                button.Clicked += handler;
            }

            return button;
        }

        private void ApplyDefaultSettings()
        {
            darkModeSwitch.IsToggled = DefaultConstants.IsDarkMode();
            fontSizeSlider.Value = DefaultConstants.GetFontSize();
            hintsToggle.IsToggled = DefaultConstants.IsHintsEnabled();
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void OnResetButtonClicked(object sender, EventArgs e)
        {
            ResetToDefaults();
        }

        private void OnSaveAndExitButtonClicked(object sender, EventArgs e)
        {
            SaveAndExit();
        }

        private void ExitWithoutSavingButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void SaveSettings()
        {
            var IsDarkMode = darkModeSwitch.IsToggled;
            var fontSize = fontSizeSlider.Value;
            var showHints = hintsToggle.IsToggled;

            Preferences.Default.Set("dark_mode", IsDarkMode);
            Preferences.Default.Set("font-size", fontSize);
            Preferences.Default.Set("show_hints", showHints);
        }

        private void ResetToDefaults()
        {
            darkModeSwitch.IsToggled = false;
            fontSizeSlider.Value = 20;
            hintsToggle.IsToggled = false;
            Preferences.Default.Set("dark_mode", false);
            Preferences.Default.Set("font-size", 20);
            Preferences.Default.Set("show_hints", false);
        }

        private void SaveAndExit()
        {
            SaveSettings();
            Navigation.PushAsync(new MainPage());
        }
    }
}

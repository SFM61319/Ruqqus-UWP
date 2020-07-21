using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ruqqus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        public static class ApplicationSettings
        {
            public const ApplicationTheme Light = ApplicationTheme.Light;
            public const ApplicationTheme Dark = ApplicationTheme.Dark;

            const string KEY_THEME = "appColourMode";
            static ApplicationDataContainer LOCALSETTINGS = ApplicationData.Current.LocalSettings;

            /// <summary>
            /// Gets or sets the current app colour setting from memory (light or dark mode).
            /// </summary>
            public static ApplicationTheme Theme
            {
                get
                {
                    // Never set: default theme
                    if (LOCALSETTINGS.Values[KEY_THEME] == null)
                    {
                        LOCALSETTINGS.Values[KEY_THEME] = (int)Light;
                        return Light;
                    }
                    // Previously set to default theme
                    else if ((int)LOCALSETTINGS.Values[KEY_THEME] == (int)Light)
                    {
                        return Light;
                    }
                    // Previously set to non-default theme
                    else
                    {
                        return Dark;
                    }
                }
                set
                {
                    if (LOCALSETTINGS.Values[KEY_THEME] == null)
                    {
                        LOCALSETTINGS.Values[KEY_THEME] = (int)value;
                    }
                    // No change
                    else if ((int)value == (int)LOCALSETTINGS.Values[KEY_THEME])
                    {
                        return;
                    }
                    // Change
                    else
                    {
                        LOCALSETTINGS.Values[KEY_THEME] = (int)value;
                    }
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DarkModeToggleSwitch.IsOn = ApplicationSettings.Theme == ApplicationSettings.Dark;
        }

        private void DarkModeToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (DarkModeToggleSwitch.IsOn)
            {
                ApplicationSettings.Theme = ApplicationSettings.Dark;
                App.Current.RequestedTheme = ApplicationSettings.Dark;
            }
            else
            {
                ApplicationSettings.Theme = ApplicationSettings.Light;
                App.Current.RequestedTheme = ApplicationSettings.Light;
            }
        }
    }
}

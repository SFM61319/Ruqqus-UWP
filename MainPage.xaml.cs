using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ruqqus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SetBackgroundAcrylicBrush();
        }

        private void SetBackgroundAcrylicBrush()
        {
            MainPageBackgroundAcrylicBrush.TintColor = Settings.ApplicationSettings.Theme == ApplicationTheme.Light ? Color.FromArgb(255, 255, 255, 255) : Color.FromArgb(255, 0, 0, 0);
        }

        private void MainPage_ActualThemeChanged(FrameworkElement sender, object args)
        {
            SetBackgroundAcrylicBrush();
        }

        private void MainPageNavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            MainPageNavigationView.SelectedItem = Home;
            MainPageContentFrame.Navigate(typeof(Home));
        }

        private void MainPageNavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer == null)
            {
                return;
            }
            
            if (args.IsSettingsInvoked)
            {
                MainPageContentFrame.Navigate(typeof(Settings));
            }
            else
            {
                switch (args.InvokedItemContainer.Tag.ToString())
                {
                    case "Home":
                        MainPageContentFrame.Navigate(typeof(Home));
                        break;
                }
            }
        }

        /*
        private void MainPageNavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (mainPageContentFrame.CanGoBack)
            {
                mainPageContentFrame.GoBack();
            }
        }
        */

        private void MainPageAppSearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }

        private void MainPageAppSearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        private void MainPageAppSearchAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private void MainPageAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

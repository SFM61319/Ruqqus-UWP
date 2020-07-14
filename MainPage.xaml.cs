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
            setBackgroundAcrylicBrush();
        }

        // Initialize a NavigationViewItem as "Home" for future uses as the last invoked navigation view item
        public NavigationViewItem _lastInvokedNavigationViewItem;

        private void setBackgroundAcrylicBrush()
        {
            mainPageBackgroundAcrylicBrush.TintColor = Application.Current.RequestedTheme == ApplicationTheme.Light ? Color.FromArgb(255, 255, 255, 255) : Color.FromArgb(255, 0, 0, 0);
        }

        private void MainPage_ActualThemeChanged(FrameworkElement sender, object args)
        {
            setBackgroundAcrylicBrush();
        }

        private void MainPageNavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            mainPageContentFrame.Navigate(typeof(Home));
        }

        private void MainPageNavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem invokedNavigationViewItem = args.InvokedItem as NavigationViewItem;

            if ((invokedNavigationViewItem == null) || (invokedNavigationViewItem == _lastInvokedNavigationViewItem))
            {
                return;
            }
            
            if (args.IsSettingsInvoked)
            {
                mainPageContentFrame.Navigate(typeof(Settings));
            }
            else
            {
                switch (invokedNavigationViewItem.Tag.ToString())
                {
                    case "Home":
                        mainPageContentFrame.Navigate(typeof(Home));
                        break;
                    
                    default:
                        mainPageContentFrame.Navigate(typeof(Home));
                        break;
                }
            }
            
            _lastInvokedNavigationViewItem = invokedNavigationViewItem;
        }

        private void MainPageNavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (mainPageContentFrame.CanGoBack)
            {
                mainPageContentFrame.GoBack();
            }
        }

        private void mainPageAppSearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }

        private void mainPageAppSearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        private void mainPageAppSearchAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private void mainPageAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

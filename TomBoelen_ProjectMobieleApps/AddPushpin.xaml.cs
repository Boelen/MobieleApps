using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TomBoelen_ProjectMobieleApps.Resources;
using System.Globalization;
using System.Device.Location;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace TomBoelen_ProjectMobieleApps
{
    public partial class AddPushpin : PhoneApplicationPage
    {

        private Geolocator locator = null;

        public AddPushpin()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();

            if (locator == null)
            {
                locator = new Geolocator();
                locator.DesiredAccuracy = PositionAccuracy.High;

            }


        }

        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/back.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);
            appBarButton.Click += appBarButton_Click;

            ZoekCoord();

            // Create a new menu item with the localized string from AppResources.
            //ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            //ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        private void appBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

       private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

         private void AddPushpin_Click(object sender, RoutedEventArgs e)
       {
          
       }

        async private void ZoekCoord()
        {
            AddPushpinButton.IsEnabled = false;

            Geoposition position = await locator.GetGeopositionAsync();
            txtLatitude.Text = position.Coordinate.Latitude.ToString();
            txtLongitude.Text = position.Coordinate.Longitude.ToString();

            AddPushpinButton.IsEnabled = true;
        }
    }
}
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
using Windows.Devices.Geolocation;
using System.Device.Location;
using Microsoft.Phone.Maps.Toolkit;
using TomBoelen_ProjectMobieleApps.ViewModels;

namespace TomBoelen_ProjectMobieleApps
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly PlaceMarkViewModel _ViewModel = new PlaceMarkViewModel();
        // Constructor
       
        // Constructor
        public MainPage()
        {

            InitializeComponent();
            this.DataContext = this._ViewModel;

           


            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            maps.SetView(new GeoCoordinate(47.6045697927475, -122.329885661602), 16);
            MapExtensions.GetChildren(maps)
            .OfType<MapItemsControl>().First()
            .ItemsSource = this._ViewModel.Placemark;
        }

        


        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/new.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);

            // Create a new menu item with the localized string from AppResources.
            //ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            //ApplicationBar.MenuItems.Add(appBarMenuItem);
        }
    }
}
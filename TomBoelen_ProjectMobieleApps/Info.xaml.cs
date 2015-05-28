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
using TomBoelen_ProjectMobieleApps.ViewModels;

namespace TomBoelen_ProjectMobieleApps
{
    public partial class Info : PhoneApplicationPage
    {

        private Geolocator locator;
        private readonly PlaceMarkViewModel _ViewModel = new PlaceMarkViewModel();

        public Info()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
            locator = new Geolocator();
            //locator.DesiredAccuracy = PositionAccuracy.High;
        

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
           if (txtLatitude.Text == "" || txtLongitude.Text == "")
           {
               MessageBox.Show("Vul eerst de longitutde & latitude in");
           }
           else
           {

               try
               {

                   _ViewModel.Items.Add(new Placemark()
                        {
                            Name = Convert.ToString(txtPushpin.Text),
                            Description = txtLatitude.Text,
                            GeoCoordinate = new GeoCoordinate(Convert.ToDouble(txtLatitude.Text), Convert.ToDouble(txtLongitude.Text))

                        });
                   _ViewModel.save();
               }
               catch(FormatException)
               {
                   MessageBox.Show("Je format van je coördinaten is niet goed!");
               }
           }
       }

        private void AddCoördinaten_Click(object sender, RoutedEventArgs e)
         {
             ZoekCoord();
         }



        async private void ZoekCoord()
        {


            Geoposition position = await locator.GetGeopositionAsync();
                txtLatitude.Text = position.Coordinate.Latitude.ToString();
                txtLongitude.Text = position.Coordinate.Longitude.ToString();
         
        }


    }
}
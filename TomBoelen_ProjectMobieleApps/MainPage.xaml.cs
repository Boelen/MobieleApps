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
using System.Windows.Threading;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Logging;
using Microsoft.Phone.Maps.Toolkit;

namespace TomBoelen_ProjectMobieleApps
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly PlaceMarkViewModel _ViewModel = new PlaceMarkViewModel();
        private GeoCoordinateWatcher _watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
        private MapPolyLine _line;
        private DispatcherTimer _Timer = new DispatcherTimer();
        private long _startTime;
        // Constructor
       
        // Constructor
        public MainPage()
        {

            InitializeComponent();
            this.DataContext = this._ViewModel;
            _Timer.Interval = TimeSpan.FromSeconds(1);
            _Timer.Tick += _Timer_Tick;


            _line = new MapPolyLine();
            _line.StrokeColor = Colors.Red;
            _line.StrokeThickness = 5;
            maps.MapElements.Add(_line);
            _watcher.PositionChanged +=_watcher_PositionChanged;


            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }



        private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this._ViewModel.LoadData();
            maps.SetView(new GeoCoordinate(47.6045697927475, -122.329885661602), 16);
            MapExtensions.GetChildren(maps)
            .OfType<MapItemsControl>().First()
            .ItemsSource = this._ViewModel.Items;
           

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

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if(_Timer.IsEnabled)
            {
                _Timer.Stop();
                StartButton.Content = "start";
            }
            else
            {
                _Timer.Start();
                _startTime = System.Environment.TickCount;
                StartButton.Content = "Stop";
            }
        }

        void _Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan runTime = TimeSpan.FromMilliseconds(System.Environment.TickCount - _startTime) ;
            timeLabel.Text = runTime.ToString(@"hh\:mm\:ss");
        }

        void _watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
          var coord = new GeoCoordinate(e.Position.Location.Latitude, e.Position.Location.Longitude);

            _line.Path.Add(coord);
        }

    }
}
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
using System.Windows.Media;
using System.IO.IsolatedStorage;

namespace TomBoelen_ProjectMobieleApps
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly PlaceMarkViewModel _ViewModel = new PlaceMarkViewModel();
        private GeoCoordinateWatcher _watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
        private MapPolyline _line;
        private DispatcherTimer _Timer = new DispatcherTimer();
        private long _startTime;
        private double _kilometers;

        // Constructor
       
        // Constructor
        public MainPage()
        {

            InitializeComponent();
            this.DataContext = this._ViewModel;
            _Timer.Interval = TimeSpan.FromSeconds(1);
            _Timer.Tick += _Timer_Tick;

            _line = new MapPolyline();
            _line.StrokeColor = Colors.Red;
            _line.StrokeThickness = 5;
            maps.MapElements.Add(_line);
            _watcher.PositionChanged += _watcher_PositionChanged;

            //Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
        }

        private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //this._ViewModel.LoadData();
            this._ViewModel.Items.Add(new Placemark()
            {
                Name = "Location 1",
                Description = "Description 1",
                GeoCoordinate = new GeoCoordinate(47.6050338745117, -122.334243774414)
            });
            this._ViewModel.Items.Add(new Placemark()
            {
                Name = "Location 2",
                Description = "Description 2",
                GeoCoordinate = new GeoCoordinate(47.6045697927475, -122.329885661602)
            });
            this._ViewModel.Items.Add(new Placemark()
            {
                Name = "Location 3",
                Description = "Description 3",
                GeoCoordinate = new GeoCoordinate(47.605712890625, -122.330268859863)
            });
            maps.SetView(new GeoCoordinate(47.6045697927475, -122.329885661602), 16);
            maps.Pitch = 55;
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
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/add.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);
            appBarButton.Click += appBarButton_Click;

            // Create a new menu item with the localized string from AppResources.
            //ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            //ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        void appBarButton_Click(object sender, EventArgs e)
        {
          NavigationService.Navigate(new Uri("/AddPushpin.xaml", UriKind.RelativeOrAbsolute));
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (_Timer.IsEnabled)
            {
                _watcher.Stop();
                _Timer.Stop();
                StartButton.Content = "start";
            }
            else
            {
                _watcher.Start();
                _Timer.Start();
                _startTime = System.Environment.TickCount;
                StartButton.Content = "Stop";
            }
        }

        void _Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan runTime = TimeSpan.FromMilliseconds(System.Environment.TickCount - _startTime);
            timeLabel.Text = runTime.ToString(@"hh\:mm\:ss");
        }

        void _watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var coord = new GeoCoordinate(e.Position.Location.Latitude, e.Position.Location.Longitude);

            if(_line.Path.Count > 0)
            {
                var previousPoint = _line.Path.Last();
                var distance = coord.GetDistanceTo(previousPoint);

                //var MiliPerKilometer = (1000.0 / distance) * (System.Environment.TickCount - _previousPositionChangeTick);

                _kilometers += distance / 1000.0;

                //paceLabel.Text = TimeSpan.FromMilliseconds(MiliPerKilometer).ToString(@"mm\:ss");

                distanceLabel.Text = string.Format("{0:f2} km", _kilometers);
                caloriesLabel.Text = String.Format("{0:f0}", _kilometers * 65);
            }

            maps.Center = coord;

            _line.Path.Add(coord);


            ShellTile.ActiveTiles.First().Update(new IconicTileData()
            {
                Title = "WP8Runner",
                WideContent1 = string.Format("{0:f2} km", _kilometers),
                WideContent2 = string.Format("{0:f0} calories", _kilometers * 65),
            });

        }

        private void ButtonAsk_Click(object sender, RoutedEventArgs e)
        {
          
        }


    }
}
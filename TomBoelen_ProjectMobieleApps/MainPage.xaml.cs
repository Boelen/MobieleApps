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
using System.Xml.Serialization;
using System.IO;
using System.Collections;

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
        private List<string> list2;
        //private List<Geocoordinate> coordinaten;
        private GeoCoordinate coord;
        //private Geolocator locator;
        //private readonly PlaceMarkViewModel _ViewModel = new PlaceMarkViewModel();

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


            //locator = new Geolocator();

            //Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this._ViewModel.LoadData();

            //MapItemsControl MIC = MapExtensions.GetChildren(maps).FirstOrDefault(x => x is MapItemsControl) as MapItemsControl;
            //if (MIC != null && MIC.ItemsSource != null)
            //{
            //            (MIC.ItemsSource as IList).Clear(); // clear old collection
            //             MIC.ItemsSource = null;
            //}

            maps.SetView(new GeoCoordinate(47.6045697927475, -122.329885661602), 16);

            maps.Pitch = 55;

            MapExtensions.GetChildren(maps)
            .OfType<MapItemsControl>().First()
            .ItemsSource = this._ViewModel.Items;
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            App thisApp = App.Current as App;
          

            if (thisApp._startTime == 0)
            {

            }
            else
            {
                _startTime = thisApp._startTime;
                _kilometers = thisApp._kilometers;
                //StartButton_Click(null,null);
 
            }

            base.OnNavigatedTo(e);
            
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            App thisApp = App.Current as App;
            thisApp._startTime = _startTime;
            thisApp._kilometers = _kilometers;

            base.OnNavigatedFrom(e);
        }
        


        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            //ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            //ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/add.png", UriKind.Relative));
            //appBarButton.Text = AppResources.AppBarButtonText;
            //ApplicationBar.Buttons.Add(appBarButton);
            //appBarButton.Click += appBarButton_Click;

            // Create a new menu item with the localized string from AppResources.
            //ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            //ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        //void appBarButton_Click(object sender, EventArgs e)
        //{
        //  NavigationService.Navigate(new Uri("/AddPushpin.xaml", UriKind.RelativeOrAbsolute));
        //}

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
                App thisApp = App.Current as App;

                _watcher.Start();
                _Timer.Start();
                //if (thisApp._startTime == 0)
                //{
                    _startTime = System.Environment.TickCount;
                //}
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
            coord = new GeoCoordinate(e.Position.Location.Latitude, e.Position.Location.Longitude);


            if(_line.Path.Count > 0)
            {
                var previousPoint = _line.Path.Last();
                var distance = coord.GetDistanceTo(previousPoint);

                //var MiliPerKilometer = (1000.0 / distance) * (System.Environment.TickCount - _previousPositionChangeTick);

                _kilometers += distance / 1000.0;

                //paceLabel.Text = TimeSpan.FromMilliseconds(MiliPerKilometer).ToString(@"mm\:ss");

                distanceLabel.Text = string.Format("{0:f2} km", _kilometers);
                caloriesLabel.Text = String.Format("{0:f0}", _kilometers * 65);
                LblLatitude.Text = Convert.ToString(e.Position.Location.Latitude);
                lblLongitude.Text = Convert.ToString(e.Position.Location.Longitude);
            }

            maps.Center = coord;

            _line.Path.Add(coord);


            ShellTile.ActiveTiles.First().Update(new IconicTileData()
            {
                Title = "Run2View",
                WideContent1 = string.Format("{0:f2} km", _kilometers),
                WideContent2 = string.Format("{0:f0} calories", _kilometers * 65),
            });

        }

        private void ButtonAsk_Click(object sender, RoutedEventArgs e)
        {
            BlockScore.Text = "";

            IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();

            if (iso.FileExists("XMP"))
            {
                IsolatedStorageFileStream stream = iso.OpenFile("XMP", FileMode.Open);
                StreamReader reader = new StreamReader(stream);

                XmlSerializer ser = new XmlSerializer(typeof(List<string>));
                list2 = ser.Deserialize(reader) as List<string>;

                reader.Close();
            }
            else
            {
                list2 = new List<string>();
            }

            iso.Dispose();


            foreach(string score in list2 )
            {
                BlockScore.Text += score + "\r\n";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //list2 = new List<string>();
            list2.Add(Convert.ToString(distanceLabel.Text) + "=" + Convert.ToString(timeLabel.Text));

            IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();

            IsolatedStorageFileStream stream = iso.CreateFile("XMP");
            StreamWriter writer = new StreamWriter(stream);

            XmlSerializer ser = new XmlSerializer(typeof(List<string>));
            ser.Serialize(writer, list2);
            writer.Close();
            iso.Dispose();

        }


        // PUSPIN

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
                catch (FormatException)
                {
                    MessageBox.Show("Je format van je coördinaten is niet goed!");
                }
            }
        }

        private void AddCoördinaten_Click(object sender, RoutedEventArgs e)
        {
            ZoekCoord();
        }



        private void ZoekCoord()
        {


            //Geoposition position = await locator.GetGeopositionAsync();
            if(coord ==null)
            {
                MessageBox.Show("Je laatste positie is niet beschikbaar. Start de Run-app en kijk als de app je locatie kan vinden.");
            }
            else{
            txtLatitude.Text = coord.Latitude.ToString();
            txtLongitude.Text = coord.Longitude.ToString();
            }

        }


    }
}
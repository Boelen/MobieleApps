using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Net;
using System.Xml.Linq;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using System.Device.Location;
using System.Runtime.CompilerServices;
using Microsoft.Phone.Maps.Controls;



namespace TomBoelen_ProjectMobieleApps.ViewModels
{
    public class PlaceMarkViewModel
    {
            public PlaceMarkViewModel()
            {
                this.Items = new ObservableCollection<Placemark>();
            }

            public ObservableCollection<Placemark> Items { get; private set; }

           public void LoadData()
            {
                this.Items.Add(new Placemark()
                {
                    Name = "Location 1",
                    Description = "Description 1",
                    GeoCoordinate = new GeoCoordinate(47.6050338745117, -122.334243774414)
                });
                this.Items.Add(new Placemark()
                {
                    Name = "Location 2",
                    Description = "Description 2",
                    GeoCoordinate = new GeoCoordinate(47.6045697927475, -122.329885661602)
                });
                this.Items.Add(new Placemark()
                {
                    Name = "Location 3",
                    Description = "Description 3",
                    GeoCoordinate = new GeoCoordinate(47.605712890625, -122.330268859863)
                });
            }
           
       



     
    }
}

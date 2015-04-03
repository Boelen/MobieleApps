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



namespace TomBoelen_ProjectMobieleApps
{
    internal class Placemark : INotifyPropertyChanged
    {
        private string _Name;
        private string _Description;
        private GeoCoordinate _GeoCoordinate;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get
            {
                return this._Name;
            }

            set
            {
                if (this._Name != value)
                {
                    this._Name = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public string Description
        {
            get
            {
                return this._Description;
            }

            set
            {
                if (this._Description != value)
                {
                    this._Description = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        [TypeConverter(typeof(GeoCoordinateConverter))]
        public GeoCoordinate GeoCoordinate
        {
            get
            {
                return this._GeoCoordinate;
            }

            set
            {
                if (this._GeoCoordinate != value)
                {
                    this._GeoCoordinate = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

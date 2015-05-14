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
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml.Serialization;



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

                IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
                
               if(iso.FileExists("XML"))
               {
                   IsolatedStorageFileStream stream = iso.OpenFile("XML",FileMode.Open );
                   StreamReader reader = new StreamReader(stream);

                   XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<Placemark>));
                   Items = ser.Deserialize(reader) as ObservableCollection<Placemark>;

                   reader.Close();
               }
               else
               {
                   Items = new ObservableCollection<Placemark>();
               }

               iso.Dispose();
           }

        public void save()
        {
            IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
          
            IsolatedStorageFileStream stream = iso.CreateFile("XML");
            StreamWriter writer = new StreamWriter(stream);

            XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<Placemark>));
            ser.Serialize(writer,Items);
            writer.Close();
            iso.Dispose();

        }

            }
           
       



     
    }

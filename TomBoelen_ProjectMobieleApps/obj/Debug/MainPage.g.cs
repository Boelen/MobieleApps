﻿#pragma checksum "C:\Users\tom\Desktop\MobieleApps\TomBoelen_ProjectMobieleApps\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3A601DF826E584F95A15173CEA3E4A7E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Toolkit;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace TomBoelen_ProjectMobieleApps {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button ButtonAsk;
        
        internal System.Windows.Controls.TextBlock BlockScore;
        
        internal Microsoft.Phone.Maps.Controls.Map maps;
        
        internal Microsoft.Phone.Maps.Toolkit.MapItemsControl mapItems;
        
        internal System.Windows.Controls.TextBlock distanceLabel;
        
        internal System.Windows.Controls.TextBlock timeLabel;
        
        internal System.Windows.Controls.TextBlock caloriesLabel;
        
        internal System.Windows.Controls.Button StartButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/TomBoelen_ProjectMobieleApps;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.ButtonAsk = ((System.Windows.Controls.Button)(this.FindName("ButtonAsk")));
            this.BlockScore = ((System.Windows.Controls.TextBlock)(this.FindName("BlockScore")));
            this.maps = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("maps")));
            this.mapItems = ((Microsoft.Phone.Maps.Toolkit.MapItemsControl)(this.FindName("mapItems")));
            this.distanceLabel = ((System.Windows.Controls.TextBlock)(this.FindName("distanceLabel")));
            this.timeLabel = ((System.Windows.Controls.TextBlock)(this.FindName("timeLabel")));
            this.caloriesLabel = ((System.Windows.Controls.TextBlock)(this.FindName("caloriesLabel")));
            this.StartButton = ((System.Windows.Controls.Button)(this.FindName("StartButton")));
        }
    }
}


﻿#pragma checksum "C:\Users\tom\Desktop\FINAAL\trunk\TomBoelen_ProjectMobieleApps\AddPushpin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1A09E78202014E72E04593C633DBA2CB"
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
    
    
    public partial class AddPushpin : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox txtPushpin;
        
        internal System.Windows.Controls.TextBox txtLongitude;
        
        internal System.Windows.Controls.TextBox txtLatitude;
        
        internal System.Windows.Controls.Button AddPushpinButton;
        
        internal System.Windows.Controls.Button AddCoördinaten;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/TomBoelen_ProjectMobieleApps;component/AddPushpin.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.txtPushpin = ((System.Windows.Controls.TextBox)(this.FindName("txtPushpin")));
            this.txtLongitude = ((System.Windows.Controls.TextBox)(this.FindName("txtLongitude")));
            this.txtLatitude = ((System.Windows.Controls.TextBox)(this.FindName("txtLatitude")));
            this.AddPushpinButton = ((System.Windows.Controls.Button)(this.FindName("AddPushpinButton")));
            this.AddCoördinaten = ((System.Windows.Controls.Button)(this.FindName("AddCoördinaten")));
        }
    }
}


﻿

#pragma checksum "C:\Work\_HPES\Treinamentos HP-ES\Windows Phone 8.1\Exemplos\GPS\CodeLab\Geolocation sample\C#\WindowsPhone\Scenario4_ForegroundGeofence.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "87CA0B1FF1953A1C1C9C8C1D34B5D1EB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Devices.Geolocation
{
    partial class Scenario4 : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid LayoutRoot; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_Main; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_InputControls; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_ListBoxes; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid Grid_ListBox; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ListBox GeofenceEventsListBox; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ListBox RegisteredGeofenceListBox; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button RemoveGeofenceItem; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid Grid_InputControls; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_NameLabel; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_Id; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_LatitudeLabel; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_Latitude; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_LongitudeLabel; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_Longitude; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_RadiusLabel; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_Radius; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_DwellTimeLabel; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_StartTimeLabel; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.StackPanel StackPanel_DurationLabel; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.CheckBox SingleUse; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox Duration; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TextBlock_Duration; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox StartTime; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TextBlock_StartTime; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button SetStartTimeToNowButton; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox DwellTime; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TextBlock_DwellTime; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox Radius; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TextBlock_Radius; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TextBlock_RadiusAsterisk; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox Longitude; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TextBlock_Longitude; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TextBlock_LongitudeAsterisk; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox Latitude; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TextBlock_Latitude; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TextBlock_LatitudeAsterisk; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button SetPositionToHereButton; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ProgressBar SetPositionProgressBar; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox Id; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock CharCount; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TextBlock_Name; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock TextBlock_NameAsterisk; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock InputTextBlock; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button CreateGeofenceButton; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///Scenario4_ForegroundGeofence.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            LayoutRoot = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("LayoutRoot");
            StackPanel_Main = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_Main");
            StackPanel_InputControls = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_InputControls");
            StackPanel_ListBoxes = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_ListBoxes");
            Grid_ListBox = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("Grid_ListBox");
            GeofenceEventsListBox = (global::Windows.UI.Xaml.Controls.ListBox)this.FindName("GeofenceEventsListBox");
            RegisteredGeofenceListBox = (global::Windows.UI.Xaml.Controls.ListBox)this.FindName("RegisteredGeofenceListBox");
            RemoveGeofenceItem = (global::Windows.UI.Xaml.Controls.Button)this.FindName("RemoveGeofenceItem");
            Grid_InputControls = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("Grid_InputControls");
            StackPanel_NameLabel = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_NameLabel");
            StackPanel_Id = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_Id");
            StackPanel_LatitudeLabel = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_LatitudeLabel");
            StackPanel_Latitude = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_Latitude");
            StackPanel_LongitudeLabel = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_LongitudeLabel");
            StackPanel_Longitude = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_Longitude");
            StackPanel_RadiusLabel = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_RadiusLabel");
            StackPanel_Radius = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_Radius");
            StackPanel_DwellTimeLabel = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_DwellTimeLabel");
            StackPanel_StartTimeLabel = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_StartTimeLabel");
            StackPanel_DurationLabel = (global::Windows.UI.Xaml.Controls.StackPanel)this.FindName("StackPanel_DurationLabel");
            SingleUse = (global::Windows.UI.Xaml.Controls.CheckBox)this.FindName("SingleUse");
            Duration = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("Duration");
            TextBlock_Duration = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TextBlock_Duration");
            StartTime = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("StartTime");
            TextBlock_StartTime = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TextBlock_StartTime");
            SetStartTimeToNowButton = (global::Windows.UI.Xaml.Controls.Button)this.FindName("SetStartTimeToNowButton");
            DwellTime = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("DwellTime");
            TextBlock_DwellTime = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TextBlock_DwellTime");
            Radius = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("Radius");
            TextBlock_Radius = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TextBlock_Radius");
            TextBlock_RadiusAsterisk = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TextBlock_RadiusAsterisk");
            Longitude = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("Longitude");
            TextBlock_Longitude = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TextBlock_Longitude");
            TextBlock_LongitudeAsterisk = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TextBlock_LongitudeAsterisk");
            Latitude = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("Latitude");
            TextBlock_Latitude = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TextBlock_Latitude");
            TextBlock_LatitudeAsterisk = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TextBlock_LatitudeAsterisk");
            SetPositionToHereButton = (global::Windows.UI.Xaml.Controls.Button)this.FindName("SetPositionToHereButton");
            SetPositionProgressBar = (global::Windows.UI.Xaml.Controls.ProgressBar)this.FindName("SetPositionProgressBar");
            Id = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("Id");
            CharCount = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("CharCount");
            TextBlock_Name = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TextBlock_Name");
            TextBlock_NameAsterisk = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("TextBlock_NameAsterisk");
            InputTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("InputTextBlock");
            CreateGeofenceButton = (global::Windows.UI.Xaml.Controls.Button)this.FindName("CreateGeofenceButton");
        }
    }
}




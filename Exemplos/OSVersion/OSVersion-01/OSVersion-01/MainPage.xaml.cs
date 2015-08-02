using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace OSVersion_01
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String strAux = null;
            Windows.Security.ExchangeActiveSyncProvisioning.EasClientDeviceInformation deviceInfo = new Windows.Security.ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
            var memoryLimit = Windows.System.MemoryManager.AppMemoryUsageLimit;

            string FriendlyName = deviceInfo.FriendlyName;
            string OperatingSystem = deviceInfo.OperatingSystem;
            string SystemManufacturer = deviceInfo.SystemManufacturer;
            string SystemProductName = deviceInfo.SystemProductName;
            string SystemFirmwareVersion = deviceInfo.SystemFirmwareVersion;
            string SystemHardwareVersion = deviceInfo.SystemHardwareVersion;
            memoryLimit = (memoryLimit / 1024) / 1024;

            strAux = strAux + "Friendly Name = " + FriendlyName + "\n";
            strAux = strAux + "Operating System = " + OperatingSystem + "\n";
            strAux = strAux + "System Manufacturer = " + SystemManufacturer + "\n";
            strAux = strAux + "System Product Name = " + SystemProductName + "\n";
            strAux = strAux + "System Firmware Version = " + SystemFirmwareVersion + "\n";
            strAux = strAux + "System Hardware Version = " + SystemHardwareVersion + "\n";
            strAux = strAux + "Total Memory = " + memoryLimit + "\n";
            txtResultado.Text = strAux;
        }
    }
}

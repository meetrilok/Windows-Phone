﻿

#pragma checksum "C:\Work\_HPES\Treinamentos HP-ES\Windows Phone 8.1\Exemplos\GPS\CodeLab\Geolocation sample\C#\Shared\Scenario1_TrackPosition.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F8CAA4527FA55DE78C15CF3C938C7E05"
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
    partial class Scenario1 : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 17 "..\..\Scenario1_TrackPosition.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.StartTracking;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 18 "..\..\Scenario1_TrackPosition.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.StopTracking;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}



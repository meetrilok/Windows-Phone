﻿

#pragma checksum "C:\Work\_HPES\Treinamentos HP-ES\Windows Phone 8.1\Exemplos\_Pendencia\Sensor\Inclinacao\CodeLab\Inclinometer sensor sample\C#\Shared\Scenario3_Calibration.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E070FE97E13A658B59F978C366D9CBB2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Devices.Sensors.InclinometerSample
{
    partial class Scenario3 : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 19 "..\..\Scenario3_Calibration.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.OnHighAccuracy;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 20 "..\..\Scenario3_Calibration.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.OnApproximateAccuracy;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 21 "..\..\Scenario3_Calibration.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.OnUnreliableAccuracy;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}



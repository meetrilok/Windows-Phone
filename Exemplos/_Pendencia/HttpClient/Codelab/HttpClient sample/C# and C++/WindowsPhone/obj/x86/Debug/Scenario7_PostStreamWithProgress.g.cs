﻿

#pragma checksum "C:\Work\_HPES\Treinamentos HP-ES\Windows Phone 8.1\Exemplos\HttpClient\Codelab\HttpClient sample\C# and C++\Shared\Scenario7_PostStreamWithProgress.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "958BF765431B137CBE18200E5F9DFF41"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SDKSample.HttpClientSample
{
    partial class Scenario7 : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 57 "..\..\..\Scenario7_PostStreamWithProgress.xaml"
                ((global::Windows.UI.Xaml.Controls.ToggleSwitch)(target)).Toggled += this.ChunkedResponseToggle_Toggled;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 59 "..\..\..\Scenario7_PostStreamWithProgress.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Start_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 60 "..\..\..\Scenario7_PostStreamWithProgress.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Cancel_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}



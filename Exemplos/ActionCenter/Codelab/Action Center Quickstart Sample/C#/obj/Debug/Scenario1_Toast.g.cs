﻿

#pragma checksum "C:\Work\_HPES\Treinamentos HP-ES\Windows Phone 8.1\Exemplos\ActionCenter\Codelab\Action Center Quickstart Sample\C#\Scenario1_Toast.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B0BED03C40A32054DA185D20BD30FA62"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Action_Center_Quickstart
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
                #line 26 "..\..\Scenario1_Toast.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.DisplayToast_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}



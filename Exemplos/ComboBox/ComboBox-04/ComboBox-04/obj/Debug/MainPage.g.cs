﻿

#pragma checksum "C:\Work\_HPES\Treinamentos HP-ES\Windows Phone 8.1\Exemplos\ComboBox\ComboBox-04\ComboBox-04\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B8C695E674EEE36A9EA961184E874773"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComboBox_04
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 34 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ComboBox)(target)).DropDownOpened += this.ComboBoxDropDownOpen;
                 #line default
                 #line hidden
                #line 35 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ComboBox)(target)).DropDownClosed += this.ComboBoxDropDownClose;
                 #line default
                 #line hidden
                #line 36 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.ComboBoxAlterada;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}



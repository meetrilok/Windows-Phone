﻿

#pragma checksum "E:\Unity\suggestions_Demo\suggestions_Demo\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EF277D2F422C295CAB96F4ABFEB0B26C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace suggestions_Demo
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
                #line 12 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target)).TextChanged += this.suggestions_TextChanged;
                 #line default
                 #line hidden
                #line 12 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target)).SuggestionChosen += this.suggestions_SuggestionChosen;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}



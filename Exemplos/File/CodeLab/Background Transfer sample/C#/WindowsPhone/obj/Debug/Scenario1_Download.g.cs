﻿

#pragma checksum "C:\Work\_HPES\Treinamentos HP-ES\Windows Phone 8.1\Exemplos\File\CodeLab\Background Transfer sample\C#\Shared\Scenario1_Download.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "50A291D00522521C723BDFAADA82EED2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackgroundTransfer
{
    partial class S1_Download : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 41 "..\..\Scenario1_Download.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.StartDownload_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 42 "..\..\Scenario1_Download.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.StartHighPriorityDownload_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 43 "..\..\Scenario1_Download.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.StartUnconstrainedDownload_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 44 "..\..\Scenario1_Download.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.PauseAll_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 45 "..\..\Scenario1_Download.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.ResumeAll_Click;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 46 "..\..\Scenario1_Download.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.CancelAll_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}



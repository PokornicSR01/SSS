﻿#pragma checksum "..\..\..\..\Windows\VlasnikWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01F3F0F3991BE9D605BF019F073D914116593A87"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SSS_Projekat_Miju.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SSS_Projekat_Miju.Windows {
    
    
    /// <summary>
    /// VlasnikWindow
    /// </summary>
    public partial class VlasnikWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Windows\VlasnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miTreneriRangiraniPoOcenama;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Windows\VlasnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miTreneriRangiraniPoZaradi;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Windows\VlasnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid myDataGrid;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\VlasnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOdjava;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SSS-Projekat-Miju;V1.0.0.0;component/windows/vlasnikwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\VlasnikWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.miTreneriRangiraniPoOcenama = ((System.Windows.Controls.MenuItem)(target));
            
            #line 11 "..\..\..\..\Windows\VlasnikWindow.xaml"
            this.miTreneriRangiraniPoOcenama.Click += new System.Windows.RoutedEventHandler(this.miTreneriRangiraniPoOcenama_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.miTreneriRangiraniPoZaradi = ((System.Windows.Controls.MenuItem)(target));
            
            #line 12 "..\..\..\..\Windows\VlasnikWindow.xaml"
            this.miTreneriRangiraniPoZaradi.Click += new System.Windows.RoutedEventHandler(this.miTreneriRangiraniPoZaradi_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.myDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.btnOdjava = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Windows\VlasnikWindow.xaml"
            this.btnOdjava.Click += new System.Windows.RoutedEventHandler(this.btnOdjava_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


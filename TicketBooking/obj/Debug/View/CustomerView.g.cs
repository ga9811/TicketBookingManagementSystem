﻿#pragma checksum "..\..\..\View\CustomerView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EC2260FFC0292FAAA62F80B25B14A87D4102DA3898333A88467A37E39D95A313"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using TicketBookingSystemWPF.View;


namespace TicketBookingSystemWPF.View {
    
    
    /// <summary>
    /// CustomerView
    /// </summary>
    public partial class CustomerView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\View\CustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TicketBookingSystemWPF.View.CustomerView CustomerView2;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\View\CustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BookingButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\View\CustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UserButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\View\CustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Admin;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\View\CustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\View\CustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox depBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\View\CustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ArrBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\View\CustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LableTo;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\View\CustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Search;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\View\CustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker SelectDate;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\CustomerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TicketBookingSystemWPF;component/view/customerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\CustomerView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CustomerView2 = ((TicketBookingSystemWPF.View.CustomerView)(target));
            return;
            case 2:
            this.BookingButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\View\CustomerView.xaml"
            this.BookingButton.Click += new System.Windows.RoutedEventHandler(this.BookingButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.UserButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\View\CustomerView.xaml"
            this.UserButton.Click += new System.Windows.RoutedEventHandler(this.UserButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Admin = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\View\CustomerView.xaml"
            this.Admin.Click += new System.Windows.RoutedEventHandler(this.Admin_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\View\CustomerView.xaml"
            this.ExitButton.Click += new System.Windows.RoutedEventHandler(this.ExitButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.depBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\..\View\CustomerView.xaml"
            this.depBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.depBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ArrBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\..\View\CustomerView.xaml"
            this.ArrBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ArrBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.LableTo = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.Search = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\View\CustomerView.xaml"
            this.Search.Click += new System.Windows.RoutedEventHandler(this.Search_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SelectDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 11:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 32 "..\..\..\View\CustomerView.xaml"
            this.dataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


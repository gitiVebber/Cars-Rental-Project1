﻿#pragma checksum "..\..\getAllFaults.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "95907DBD1B3C9861D8D712A909400BCE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BE;
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


namespace bsd {
    
    
    /// <summary>
    /// getAllFaults
    /// </summary>
    public partial class getAllFaults : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\getAllFaults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lable1;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\getAllFaults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lable2;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\getAllFaults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid faultDataGrid;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\getAllFaults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dateOfFaultColumn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\getAllFaults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn garageOfFixColumn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\getAllFaults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn isWearColumn;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\getAllFaults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn numberCarColumn;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\getAllFaults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn numberFaultColumn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\getAllFaults.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn priceOfFaultColumn;
        
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
            System.Uri resourceLocater = new System.Uri("/bsd;component/getallfaults.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\getAllFaults.xaml"
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
            
            #line 5 "..\..\getAllFaults.xaml"
            ((bsd.getAllFaults)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lable1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lable2 = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.faultDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.dateOfFaultColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.garageOfFixColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.isWearColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 8:
            this.numberCarColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 9:
            this.numberFaultColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 10:
            this.priceOfFaultColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


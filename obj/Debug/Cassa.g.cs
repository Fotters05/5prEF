﻿#pragma checksum "..\..\Cassa.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CAAAFD22FA26E7ABA64903F0EED903DB60DD6C5063383A855587716F30D8E022"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Praktika5;
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


namespace Praktika5 {
    
    
    /// <summary>
    /// Cassa
    /// </summary>
    public partial class Cassa : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Cassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SushiBarHarmony;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Cassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listbox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Cassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Vneseno;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Cassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Spos;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Cassa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox All;
        
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
            System.Uri resourceLocater = new System.Uri("/Praktika5;component/cassa.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Cassa.xaml"
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
            this.SushiBarHarmony = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\Cassa.xaml"
            this.SushiBarHarmony.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SushiBarHarmony_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 18 "..\..\Cassa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 19 "..\..\Cassa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 20 "..\..\Cassa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Minus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.listbox = ((System.Windows.Controls.ListBox)(target));
            
            #line 21 "..\..\Cassa.xaml"
            this.listbox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Vneseno = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\Cassa.xaml"
            this.Vneseno.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Vneseno_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 23 "..\..\Cassa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Chek_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Spos = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            
            #line 25 "..\..\Cassa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Chek_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.All = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\Cassa.xaml"
            this.All.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.All_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


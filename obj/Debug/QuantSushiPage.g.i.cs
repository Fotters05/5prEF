﻿#pragma checksum "..\..\QuantSushiPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AC4A9550B9F4EEF8378811709C952A09EB96EF7A1F3678331DB6FCF96991E19A"
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
    /// QuantSushiPage
    /// </summary>
    public partial class QuantSushiPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\QuantSushiPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SushiBarHarmony;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\QuantSushiPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Quant;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\QuantSushiPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Sushi;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\QuantSushiPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Ingr;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\QuantSushiPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Q;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\QuantSushiPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock N;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\QuantSushiPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ID;
        
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
            System.Uri resourceLocater = new System.Uri("/Praktika5;component/quantsushipage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\QuantSushiPage.xaml"
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
            
            #line 12 "..\..\QuantSushiPage.xaml"
            this.SushiBarHarmony.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SushiBarHarmony_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 22 "..\..\QuantSushiPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowMainWindow);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Quant = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Sushi = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Ingr = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Q = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.N = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.ID = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            
            #line 29 "..\..\QuantSushiPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 30 "..\..\QuantSushiPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Del_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 31 "..\..\QuantSushiPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Upd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


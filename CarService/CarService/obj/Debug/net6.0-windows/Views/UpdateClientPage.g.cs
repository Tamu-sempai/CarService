﻿#pragma checksum "..\..\..\..\Views\UpdateClientPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7472DCB673AF51BA50563D7FCBDF94D0800BF534"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CarService.Views;
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


namespace CarService.Views {
    
    
    /// <summary>
    /// UpdateClientPage
    /// </summary>
    public partial class UpdateClientPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Views\UpdateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label headerLabel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\UpdateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fio;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Views\UpdateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox city;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Views\UpdateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox address;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\UpdateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox number;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\UpdateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtPlaceholderNumber;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Views\UpdateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox email;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Views\UpdateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtPlaceholderEmail;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CarService;component/views/updateclientpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\UpdateClientPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.headerLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.fio = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.city = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.address = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.number = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\..\Views\UpdateClientPage.xaml"
            this.number.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.number_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtPlaceholderNumber = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.email = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\..\Views\UpdateClientPage.xaml"
            this.email.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.email_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtPlaceholderEmail = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            
            #line 41 "..\..\..\..\Views\UpdateClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.saveChanges);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 42 "..\..\..\..\Views\UpdateClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.goBack);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


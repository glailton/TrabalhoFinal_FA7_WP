﻿#pragma checksum "c:\users\glail\OneDrive\Documentos\Visual Studio 2015\Projects\TrabalhoFinal_FA7_WP\TrabalhoFinal_FA7_WP\view\UsuarioProjetos.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6A8BDB49A1A919FB6FD7A5AFF99C0304"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace TrabalhoFinal_FA7_WP.view {
    
    
    public partial class UsuarioProjetos : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.TextBox txtUsuario;
        
        internal System.Windows.Controls.Button btnListarProjetos;
        
        internal System.Windows.Controls.ListBox repositories;
        
        internal System.Windows.Controls.StackPanel ContentPanel;
        
        internal System.Windows.Controls.HyperlinkButton btnVoltar;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/TrabalhoFinal_FA7_WP;component/view/UsuarioProjetos.xaml", System.UriKind.Relative));
            this.txtUsuario = ((System.Windows.Controls.TextBox)(this.FindName("txtUsuario")));
            this.btnListarProjetos = ((System.Windows.Controls.Button)(this.FindName("btnListarProjetos")));
            this.repositories = ((System.Windows.Controls.ListBox)(this.FindName("repositories")));
            this.ContentPanel = ((System.Windows.Controls.StackPanel)(this.FindName("ContentPanel")));
            this.btnVoltar = ((System.Windows.Controls.HyperlinkButton)(this.FindName("btnVoltar")));
        }
    }
}

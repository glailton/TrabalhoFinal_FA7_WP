﻿#pragma checksum "C:\Users\glail\OneDrive\Documentos\Visual Studio 2015\Projects\TrabalhoFinal_FA7_WP\TrabalhoFinal_FA7_WP\view\CadastraUsuario.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "81BE86A420D929C0ACDA10D1DB165523"
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
    
    
    public partial class CadastraUsuario : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.StackPanel content;
        
        internal System.Windows.Controls.TextBox txtUsuario;
        
        internal System.Windows.Controls.Button btnCadastrarUsuario;
        
        internal System.Windows.Controls.ListBox listaUsuarios;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/TrabalhoFinal_FA7_WP;component/view/CadastraUsuario.xaml", System.UriKind.Relative));
            this.content = ((System.Windows.Controls.StackPanel)(this.FindName("content")));
            this.txtUsuario = ((System.Windows.Controls.TextBox)(this.FindName("txtUsuario")));
            this.btnCadastrarUsuario = ((System.Windows.Controls.Button)(this.FindName("btnCadastrarUsuario")));
            this.listaUsuarios = ((System.Windows.Controls.ListBox)(this.FindName("listaUsuarios")));
        }
    }
}


﻿#pragma checksum "C:\Users\glail\OneDrive\Documentos\Visual Studio 2015\Projects\TrabalhoFinal_FA7_WP\TrabalhoFinal_FA7_WP\view\UsuarioProjetos.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E909F7A1030E2444A5A47DFC5B48505A"
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
        
        internal Microsoft.Phone.Controls.ListPicker lspusuarios;
        
        internal System.Windows.Controls.Button btnListarProjetos;
        
        internal System.Windows.Controls.Button btnCadastrarUsuario;
        
        internal System.Windows.Controls.ListBox repositories;
        
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
            this.lspusuarios = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lspusuarios")));
            this.btnListarProjetos = ((System.Windows.Controls.Button)(this.FindName("btnListarProjetos")));
            this.btnCadastrarUsuario = ((System.Windows.Controls.Button)(this.FindName("btnCadastrarUsuario")));
            this.repositories = ((System.Windows.Controls.ListBox)(this.FindName("repositories")));
        }
    }
}


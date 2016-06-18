using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TrabalhoFinal_FA7_WP.Resources;
using System.Globalization;

namespace TrabalhoFinal_FA7_WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnProjetos_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/UsuarioProjetos.xaml", UriKind.Relative));
        }

        private void btnCadastro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/CadastraUsuario.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
    }
}
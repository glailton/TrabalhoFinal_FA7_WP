using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace TrabalhoFinal_FA7_WP.view
{
    public partial class UsuarioProjetos : PhoneApplicationPage
    {
        public UsuarioProjetos()
        {
            InitializeComponent();
        }

        private async void btnListarProjetos_Click(object sender, RoutedEventArgs e)
        {
            var gitHubRepositories = new GitHubRepositories();
            var lista = await gitHubRepositories.GetRepositories(txtUsuario.Text);
            repositories.ItemsSource = lista;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
    }
}
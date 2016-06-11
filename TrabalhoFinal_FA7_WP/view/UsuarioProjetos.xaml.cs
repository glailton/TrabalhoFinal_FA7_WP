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
            CarregarUsuarios();
        }

        private async void btnListarProjetos_Click(object sender, RoutedEventArgs e)
        {
            var gitHubRepositories = new GitHubRepositories();
            var lista = await gitHubRepositories.GetRepositories(lspusuarios.SelectedItem as string);
            repositories.ItemsSource = lista;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        void CarregarUsuarios()
        {
            using (var db = new bd.UsuarioDataContext())
            {
                var resultado = (from usuario in db.usuarios
                                 orderby usuario.Nome

                                 select usuario).ToList();
                // lspusuarios.Items.Add(resultado);
                List<string> listaNomes = new List<string>();
                
                foreach(var nome in resultado)
                {
                    listaNomes.Add(nome.Nome);
                }

                lspusuarios.ItemsSource = listaNomes;
            }


        }
    }
}
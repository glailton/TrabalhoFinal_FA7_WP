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
            listarProjetos();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }


        private async void listarProjetos()
        {
            var gitHubRepositories = new GitHubRepositories();
            var lista = await gitHubRepositories.GetRepositories(lspusuarios.SelectedItem as string);
            repositories.ItemsSource = lista;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //Chamado quando o usuario clica no Tile Secundario
            if (NavigationContext.QueryString.ContainsKey("nome"))
            {
                string nome = NavigationContext.QueryString["nome"];
                lspusuarios.SelectedItem = nome;
                listarProjetos();
            }

            // Chamando quando retorno do modo Tombstoned
            if (State.ContainsKey("usuario_atual"))
            {
                lspusuarios.SelectedItem = State["usuario_atual"] as string;
                repositories.ItemsSource = (List<string>)State["projetos_usuario_atual"];
            }


        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Salva o estado da página se a navegação não for pelo botão Back
            if (e.NavigationMode != NavigationMode.Back)
            {
                State["usuario_atual"] = lspusuarios.SelectedItem;
                State["projetos_usuario_atual"] = repositories.ItemsSource;
            }

            base.OnNavigatedFrom(e);
        }




        void CarregarUsuarios()
        {
            using (var db = new bd.UsuarioDataContext())
            {
                var resultado = (from usuario in db.usuarios
                                 orderby usuario.Nome

                                 select usuario).ToList();

                List<string> listaNomes = new List<string>();

                foreach (var nome in resultado)
                {
                    listaNomes.Add(nome.Nome);
                }

                lspusuarios.ItemsSource = listaNomes;
            }
        }

        private void btnCadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/CadastraUsuario.xaml", UriKind.Relative));
        }
    }
}
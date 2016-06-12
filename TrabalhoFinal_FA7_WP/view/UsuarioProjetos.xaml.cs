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
        bool isNewInstance;

        public UsuarioProjetos()
        {
            InitializeComponent();
            isNewInstance = true;
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

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            //salva dados da aplicacao em uma tabela hash quando entra em tombstoned
            State["nome"] = lspusuarios.SelectedItem.ToString();
            isNewInstance = false;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            /*  if (isNewInstance)
              {
                  //recupera os dados qdo volta a rodar a aplicação
                  if (State.ContainsKey("nome"))
                  {
                      lspusuarios.SelectedItem = State["nome"].ToString();
                      //txtTeste.Text = State["nome"].ToString();
                  }
              */

            //Chamado quando o usuario clica no Tile Secundario
            if (NavigationContext.QueryString.ContainsKey("nome"))
            {
                string nome = NavigationContext.QueryString["nome"];
                lspusuarios.SelectedItem = nome;
            }

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
    }
}
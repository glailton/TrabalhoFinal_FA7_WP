using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TrabalhoFinal_FA7_WP.model;
using TrabalhoFinal_FA7_WP.bd;

namespace TrabalhoFinal_FA7_WP.view
{
    public partial class CadastraUsuario : PhoneApplicationPage
    {
        bool isNewInstance;

        public CadastraUsuario()
        {
            InitializeComponent();
            CarregarUsuarios();
        }

        private void btnCadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario()
            {
                Nome = txtUsuario.Text
            };
            using (var db = new UsuarioDataContext())
            {
                db.usuarios.InsertOnSubmit(usuario);
                db.SubmitChanges();

                MessageBox.Show("Inserido com sucesso");
                txtUsuario.Text = "";
                CarregarUsuarios();
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir usuário?", "Remover", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Image img = (Image)sender;
                Usuario aluno = (Usuario)img.DataContext;

                using (var db = new UsuarioDataContext())
                {
                    db.usuarios.Attach(aluno);
                    db.usuarios.DeleteOnSubmit(aluno);
                    db.SubmitChanges();

                    MessageBox.Show("Removido com sucesso");
                    CarregarUsuarios();
                }
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            //salva dados da aplicacao em uma tabela hash quando entra em tombstoned
            if (!txtUsuario.Text.Equals(""))
            {
                State["nome"] = txtUsuario.Text;
            }          
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

            if (!isNewInstance)
            {
                //recupera os dados qdo volta a rodar a aplicação
                if (NavigationContext.QueryString.ContainsKey("nome"))
                {
                    txtUsuario.Text = State["nome"].ToString();
                }
            }

        }

        void CarregarUsuarios()
        {
            using (var db = new bd.UsuarioDataContext())
            {
                var resultado = (from usuario in db.usuarios
                                 orderby usuario.Nome
                                 select usuario).ToList();
                listaUsuarios.ItemsSource = resultado;
            }
        }

        private void listaUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MessageBox.Show("Deseja criar um tile para esse usuário?", "Criar Tile Secundário", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                //Nesse metodo é verificado se o usuário deseja criar um Tile secundario para o usuario cadastrado
                var mySelectedItem = listaUsuarios.SelectedItem as Usuario;

                Uri uri = new Uri("/view/UsuarioProjetos.xaml?nome=" + mySelectedItem.Nome, UriKind.Relative);
                ShellTile existe = ShellTile.ActiveTiles.FirstOrDefault(
                    x => x.NavigationUri.Equals(uri));

                if (existe == null)
                {
                    StandardTileData dados = new StandardTileData();
                    dados.Title = mySelectedItem.Nome;
                    dados.BackTitle = mySelectedItem.Nome;
                    dados.BackgroundImage = new Uri("Assets/Tiles/download.jpg", UriKind.Relative);
                    ShellTile.Create(uri, dados);
                }
                else
                {
                    MessageBox.Show("Tile já existe");
                }
            }
               
        }
    }
}
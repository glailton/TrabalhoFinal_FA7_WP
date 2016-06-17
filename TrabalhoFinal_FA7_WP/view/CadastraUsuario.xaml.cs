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
using TrabalhoFinal_FA7_WP.Resources;

namespace TrabalhoFinal_FA7_WP.view
{
    public partial class CadastraUsuario : PhoneApplicationPage
    {

        bool _isNewPageInstance;

        public CadastraUsuario()
        {
            InitializeComponent();
            _isNewPageInstance = true;
            CarregarUsuarios();
        }

        private void btnCadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario()
            {
                Nome = txtUsuario.Text
            };

            if (txtUsuario.Text.Equals(""))
            {
                MessageBox.Show(AppResources.validUser);
            }
            else
            {
                using (var db = new UsuarioDataContext())
                {
                    db.usuarios.InsertOnSubmit(usuario);
                    db.SubmitChanges();

                    MessageBox.Show(AppResources.userAdded);
                    txtUsuario.Text = "";
                    CarregarUsuarios();
                }
            }         
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //variaveis para saber qual tile deve ser removido caso o usuario seja removido do banco
            var mySelectedItem = listaUsuarios.SelectedItem as Usuario;
            ShellTile TileToFind = null;

            if (MessageBox.Show(AppResources.removeUserAsk, AppResources.removeUserTitle, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Image img = (Image)sender;
                Usuario usuario = (Usuario)img.DataContext;

                TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(mySelectedItem.Nome));

                using (var db = new UsuarioDataContext())
                {
                    db.usuarios.Attach(usuario);
                    db.usuarios.DeleteOnSubmit(usuario);
                    db.SubmitChanges();

                    MessageBox.Show(AppResources.sucessRemoved);
                    CarregarUsuarios();
                }
            }

            // Se o tile existia e o usuario foi removido ele é removido
            if (TileToFind != null)
            {
                TileToFind.Delete();
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
	//		State["novo_usuario"] = txtUsuario.Text;

            if (_isNewPageInstance)
            {
                // Chamando quando retorno do modo Tombstoned
                if (State.ContainsKey("usuario_atual"))
                {
                    txtUsuario.Text = State["usuario_atual"] as string;
                }
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // Salva o estado da página se a navegação não for pelo botão Back
            if (e.NavigationMode != NavigationMode.Back)
            {
                State["usuario_atual"] = txtUsuario.Text;
            }
            _isNewPageInstance = false;
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

        private void ImageAdd_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (MessageBox.Show(AppResources.createSecTileAsk, AppResources.createSecTileTitle, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
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
                    MessageBox.Show(AppResources.existedTile);
                }
            }
        }

        private void btnProjetoUsuario_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/UsuarioProjetos.xaml", UriKind.Relative));
        }
    }
}
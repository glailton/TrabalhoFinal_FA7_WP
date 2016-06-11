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
    }
}
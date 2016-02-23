using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.bo;
using wpf_wakusese.src.main.model.ce;
using wpf_wakusese.src.main.model.servicos;

namespace wpf_wakusese.src.main.viewControl
{
    /// <summary>
    /// Interaction logic for TelaLogin.xaml
    /// </summary>
    public partial class TelaLogin : MetroWindow
    {

        DominioSeguranca domSeguranca = new DominioSeguranca();
        BO_UsuarioPerfil boUsuarioPerfil = (BO_UsuarioPerfil)FactoryBO<UsuarioPerfil>.GetBO();
        BO_Perfil boPerfil = (BO_Perfil)FactoryBO<Perfil>.GetBO();
        IconUtil util = new IconUtil();

        public TelaLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            var metroWindow = (Application.Current.MainWindow as MetroWindow);
            metroWindow.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Theme;

            if (String.IsNullOrEmpty(txtSenha.Password) || String.IsNullOrEmpty(txtTelefoneOrEmail.Text))
            {
                lbMessagem.Visibility = Visibility.Visible;
                lbMessagem.Content = " Preencha todos os campos!";
                //metroWindow.ShowMessageAsync("Login", " Preencha todos os campos!", MessageDialogStyle.Affirmative, null);

            }
            else
            {
                try
                {
                    Usuario usuarioLogado = new Usuario();
                    String telefoneOrEmail = txtTelefoneOrEmail.Text;
                    String senha = txtSenha.Password;

                    usuarioLogado = domSeguranca.doAutenticarUsuario(telefoneOrEmail, senha);

                    if (usuarioLogado.ListaEmpresa.Count() < 2)
                    {
                        TelaPrincipal janela = new TelaPrincipal(usuarioLogado);
                        janela.Show();
                        Close();
                    }
                    else
                    {
                        PopupSelecionarEmpresa janela = new PopupSelecionarEmpresa(usuarioLogado);
                        janela.Show();
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    lbMessagem.Visibility = Visibility.Visible;
                    lbMessagem.Content = ex.Message;
                    //metroWindow.ShowMessageAsync("Login", ex.Message, MessageDialogStyle.Affirmative, null);

                }
                finally
                {

                }
            }

        }

        private void TeclaEnterPressionada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnLogin_Click(sender, e);

            }

        }
    }
}

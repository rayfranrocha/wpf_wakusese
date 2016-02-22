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
                metroWindow.ShowMessageAsync("Login", " Preencha todos os campos!", MessageDialogStyle.Affirmative, null);

            }
            else
            {
                try
                {
                    Usuario usuarioLogado = new Usuario();
                    String telefoneOrEmail = txtTelefoneOrEmail.Text;
                    String senha = txtSenha.Password;

                    usuarioLogado = domSeguranca.doAutenticarUsuario(telefoneOrEmail, senha);
                    if (usuarioLogado != null)
                    {
                        
                        ObservableCollection<UsuarioPerfil> ListaUsuarioPerfil =util.ConverterL2OC(boUsuarioPerfil.ObterListaUsuarioPerfil(usuarioLogado));

                        ObservableCollection<Perfil> Listaperfil = new ObservableCollection<Perfil>();

                        foreach (var item in ListaUsuarioPerfil)
                        {
                            Listaperfil.Add(boPerfil.ObterPerfil(item));

                        }

                        ObservableCollection<Empresa> ListaEmpresa = new ObservableCollection<Empresa>(from c in Listaperfil
                                                                                                       select c.empresa);

                        if (ListaEmpresa.Distinct().Count() < 2)
                        {
                            Empresa emp = new Empresa();
                            emp = ListaEmpresa[0];
                            TelaPrincipal janela = new TelaPrincipal(usuarioLogado, emp);
                            janela.Show();
                            Close();
                        }
                        else
                        {
                            //TelaPerfilLogin janela = new TelaPerfilLogin(Listaperfil, usuarioLogado);
                            //   janela.Show();
                            MessageBox.Show("Escolha empresa ... tela");
                            Close();
                        }
                    }


                }
                catch (Exception ex)
                {
                    metroWindow.ShowMessageAsync("Login", ex.Message, MessageDialogStyle.Affirmative, null);

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

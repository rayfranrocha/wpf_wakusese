using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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

namespace wpf_wakusese.src.main.viewControl.cadastros
{
    /// <summary>
    /// Interaction logic for PopupInserirUsuario.xaml
    /// </summary>
    public partial class PopupInserirUsuario : MetroWindow
    { int ultimaLinhaFocada;// = null;
        BO_Empresa boEmpresa = (BO_Empresa)FactoryBO<Empresa>.GetBO();
        BO_Perfil boPerfil = (BO_Perfil)FactoryBO<Perfil>.GetBO();
        BO_Usuario boUsuario = (BO_Usuario)FactoryBO<Usuario>.GetBO();
        IconUtil util = new IconUtil();

        public PopupInserirUsuario()
        {
            InitializeComponent();
            ListaPerfil.ItemsSource = IconUtil.ConverterL2OC(boPerfil.ObterListaObjeto());
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(txtNomeCliente.Text) || String.IsNullOrEmpty(txtTelefone.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtCep.Text) || String.IsNullOrEmpty(txtLogradouro.Text))
            {
                System.Windows.Forms.MessageBox.Show("Cadastrar Cliente", " Preencha todos os campos obrigatórios!");
            }
            else
            {
                Usuario usuario = new Usuario();
                usuario.nome = txtNomeCliente.Text;
                usuario.dataNascimento = Convert.ToDateTime(txtDtNascimento.Text);
                usuario.email = txtEmail.Text;
                usuario.facebook = txtFacebook.Text;
                usuario.instagram = txtInstagram.Text;
                usuario.senha = txtSenha.Text;
                usuario.telefone = txtTelefone.Text;
                usuario.endereco.logradouro = txtLogradouro.Text;
                usuario.endereco.longitude = Convert.ToDecimal(txtLongitude.Text);
                usuario.endereco.latitude = Convert.ToDecimal(txtLatitude.Text);



                boUsuario.InserirOuAlterar(usuario);
            }
        }
    }
}

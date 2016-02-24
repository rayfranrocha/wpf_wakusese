using MahApps.Metro.Controls;
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

namespace wpf_wakusese.src.main.viewControl
{
    /// <summary>
    /// Interaction logic for PopupSelecionarEmpresa.xaml
    /// </summary>
    public partial class PopupSelecionarEmpresa : MetroWindow
    {
        Usuario usuarioLog = new Usuario();
        Empresa empLogada = new Empresa();

        BO_Usuario boUsuario = (BO_Usuario) FactoryBO<Usuario>.GetBO();

        //public ObservableCollection<Empresa> ListaEmpresa
        //{
        //    get { return (ObservableCollection<Empresa>)GetValue(empresasProperty); }
        //    set { SetValue(empresasProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static DependencyProperty empresasProperty =
        //    DependencyProperty.Register("ListaEmpresa", typeof(ObservableCollection<Empresa>), typeof(PopupSelecionarEmpresa));


        public PopupSelecionarEmpresa(Usuario usuarioLogado)
        {
            InitializeComponent();

            usuarioLog = usuarioLogado;

            cmbEmpresa.ItemsSource = usuarioLogado.ListaEmpresa;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            empLogada = cmbEmpresa.SelectedValue as Empresa;

            if (empLogada == null)
            {
                System.Windows.Forms.MessageBox.Show("Selecione uma Empresa!");
            }
            else
            {
                //atualiza ultimaEmpresa do usuario logado
                //BO_Endereco boEndereco = (BO_Endereco)FactoryBO<Endereco>.GetBO();
                //boEndereco.Attach(empLogada.endereco);
                usuarioLog.ultimaEmpresa = empLogada;
                boUsuario.InserirOuAlterar(usuarioLog);
                boUsuario.SaveChanges();
                
                //chama a tela principal
                TelaPrincipal janela = new TelaPrincipal(usuarioLog, empLogada);
                janela.Show();
                Close();
            }

        }
    }
}

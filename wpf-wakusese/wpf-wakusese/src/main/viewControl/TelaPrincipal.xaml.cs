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
using wpf_wakusese.src.main.model.ce;
using wpf_wakusese.src.main.model.servicos;
using wpf_wakusese.src.main.viewControl.cadastros;


namespace wpf_wakusese.src.main.viewControl
{
    /// <summary>
    /// Interaction logic for TelaPrincipal.xaml
    /// </summary>
    public partial class TelaPrincipal : MetroWindow
    {
        DominioSeguranca domSeguranca = new DominioSeguranca();

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = this;
        }

        public bool isClose = true;

        public Usuario usuarioLogado = new Usuario();
        public Empresa empLogada = new Empresa();

        public TelaPrincipal()
        {
            InitializeComponent();
        }

        public TelaPrincipal(Usuario usuarioLog, Empresa empresaLog)
        {
            InitializeComponent();
            this.Cursor = Cursors.Arrow;

            usuarioLogado = usuarioLog;

            empLogada = empresaLog;
            domSeguranca.doAtualizarPermissoesUsuario(empLogada, usuarioLogado);

            txtEmpresa.Text = empLogada.nome;
            txtUsuarioLogado.Text = usuarioLogado.nome;
        }

        public TelaPrincipal(UsuarioPerfil usuarioLog)
        {
            
            InitializeComponent();
            
            //this.Cursor = Cursors.Arrow;

            //usuarioLogado = bo.daoUsuario.ObterObjetoPorId(usuarioLog.usuario.id);

            //empLogada = bo.daoEmpresa.ObterEmpresaPorId(1);  //********************************************************
            //bo.doAtualizarPermissoesUsuario(empLogada, usuarioLogado);

            //txtUsuarioLogado.Text = usuarioLogado.nome;
        }

        private void OnWindowStateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void stkPbtnsAdministrativo_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (object child in stkPbtnsAdministrativo.Children)
            {
                if (child is UserControl)
                {
                    UserControl btn = (UserControl)child;
                    btn.IsEnabled = usuarioLogado.isPossuiAcesso(btn.Name) ? true : false;
                    if (btn.IsEnabled == false)
                        btn.Opacity = 0.1;

                }

            }
        }

        private void stkBtnsVenda_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (object child in stkBtnsVenda.Children)
            {
                if (child is UserControl)
                {
                    UserControl btn = (UserControl)child;
                    btn.IsEnabled = usuarioLogado.isPossuiAcesso(btn.Name) ? true : false;
                    if (btn.IsEnabled == false)
                        btn.Opacity = 0.1;

                }

            }
        }

        private void _this_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isClose == false)
            {
                e.Cancel = true;

            }
        }

        #region Botões UserControl

        private void btnPedidoDelivery_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            //TelaListaPedidosDelivery frm = new TelaListaPedidosDelivery(this);
            //stkContent.Content = frm;
            this.Cursor = Cursors.Arrow;
        }

        private void btnPedidosLocal_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            //TelaListaPedidosLocalConsumindo frm = new TelaListaPedidosLocalConsumindo(this);
            //stkContent.Content = frm;
            this.Cursor = Cursors.Arrow;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            //TelaCliente frm = new TelaCliente();
            //stkContent.Content = frm;
            this.Cursor = Cursors.Arrow;
        }

        private void btnValePresenteAvulso_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            //TelaValePresenteAvulso frm = new TelaValePresenteAvulso();
            //stkContent.Content = frm;
            this.Cursor = Cursors.Arrow;
        }

        private void btnCategoriaProdutos_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            //TelaCategoria frm = new TelaCategoria();
            //stkContent.Content = frm;
            this.Cursor = Cursors.Arrow;
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            TelaEmpresa frm = new TelaEmpresa(this);
            stkContent.Content = frm;
            this.Cursor = Cursors.Arrow;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            TelaUsuarios frm = new TelaUsuarios(this);
            stkContent.Content = frm;
            this.Cursor = Cursors.Arrow;
        }

        private void btnFuncionalidades_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            TelaFuncionalidades frm = new TelaFuncionalidades(this);
            stkContent.Content = frm;
            this.Cursor = Cursors.Arrow;
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            TelaProduto frm = new TelaProduto(this);
            stkContent.Content = frm;
            this.Cursor = Cursors.Arrow;
        }

        private void btnPromocao_Click(object sender, EventArgs e)
        {

        }

        private void btnSairLogout_Click(object sender, EventArgs e)
        {
            TelaLogin frm = new TelaLogin();
            frm.ShowDialog();
            Close();
        }

        #endregion
    }
}

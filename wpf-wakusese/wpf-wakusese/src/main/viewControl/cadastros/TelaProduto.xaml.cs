using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.bo;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.viewControl.cadastros
{
    /// <summary>
    /// Interaction logic for TelaProduto.xaml
    /// </summary>
    public partial class TelaProduto : UserControl
    {
        BO_Produto boProduto = new BO_Produto();
        BO_Categoria boCategoria = new BO_Categoria();
        IconUtil util = new IconUtil();

        #region

        public static DependencyProperty produtosProperty = DependencyProperty.Register("produtos", typeof(ObservableCollection<Produto>), typeof(TelaProduto));

        public ObservableCollection<Produto> produtos
        {
            get { return (ObservableCollection<Produto>)GetValue(produtosProperty); }
            set { SetValue(produtosProperty, value); }
        }

        public static DependencyProperty categoriasProperty = DependencyProperty.Register("categorias", typeof(ObservableCollection<Categoria>), typeof(TelaProduto));

        public ObservableCollection<Categoria> categorias
        {
            get { return (ObservableCollection<Categoria>)GetValue(categoriasProperty); }
            set { SetValue(categoriasProperty, value); }
        }

        #endregion

        TelaPrincipal frmTelaPrincipal;
        public TelaProduto(TelaPrincipal telaPrincipalInfo)
        {
            InitializeComponent();
            frmTelaPrincipal = telaPrincipalInfo;
            categorias = new ObservableCollection<Categoria>();
            produtos = new ObservableCollection<Produto>();

            doConsultar();
        }

        private void doConsultar()
        {
            tvProduto.AllowEditing = false;

            categorias = IconUtil.ConverterL2OC(boCategoria.ObterListaCategoriadaEmpresa(frmTelaPrincipal.empLogada));
            if (categorias == null)
            {
                MessageBox.Show("Não há regitros de categoria(s) no banco de dados!");
                //_this = null;
                btnNovo.IsEnabled = btnEditar.IsEnabled = false;
            }
            else
            {
                produtos = IconUtil.ConverterL2OC(boProduto.ObterListaProdutosdaEmpresa(frmTelaPrincipal.empLogada));
                frmTelaPrincipal.tabControlMenu.IsEnabled = true;
            }            

        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            _this.Opacity = 0.2;
            PopupInserirProduto janela = new PopupInserirProduto(frmTelaPrincipal);
            janela.ShowDialog();
            _this.Opacity = 10;

            doConsultar();
        }

        private void gcProduto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void imgProduto_ConvertEditValue(DependencyObject sender, DevExpress.Xpf.Editors.ConvertEditValueEventArgs args)
        {
            if (args.ImageSource != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)args.ImageSource));
                    encoder.Save(stream);
                    args.EditValue = stream.ToArray();
                    args.Handled = true;
                }
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            frmTelaPrincipal.stkContent.Content = null;
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.bo;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.viewControl.cadastros
{
    /// <summary>
    /// Interaction logic for TelaCategoria.xaml
    /// </summary>
    public partial class TelaCategoria : UserControl
    {
        BO_Categoria boCategoria = (BO_Categoria)FactoryBO<Categoria>.GetBO();
        BO_Empresa boEmpresa = (BO_Empresa)FactoryBO<Empresa>.GetBO();

        IconUtil util = new IconUtil();

        int ultimaLinhaFocada;

        public static DependencyProperty categoriasProperty = DependencyProperty.Register("categorias", typeof(ObservableCollection<Categoria>), typeof(TelaCategoria));

        public ObservableCollection<Categoria> categorias
        {
            get { return (ObservableCollection<Categoria>)GetValue(categoriasProperty); }
            set { SetValue(categoriasProperty, value); }
        }

        public static DependencyProperty empresasProperty = DependencyProperty.Register("empresas", typeof(ObservableCollection<Empresa>), typeof(TelaCategoria));

        public ObservableCollection<Empresa> empresas
        {
            get { return (ObservableCollection<Empresa>)GetValue(empresasProperty); }
            set { SetValue(empresasProperty, value); }
        }

        TelaPrincipal frmTelaPrincipal;
        public TelaCategoria(TelaPrincipal telaPrincipalInfo)
        {
            InitializeComponent();
            frmTelaPrincipal = telaPrincipalInfo;
            empresas = new ObservableCollection<Empresa>();
            categorias = new ObservableCollection<Categoria>();
            doConsultar();
        }

        private void doConsultar()
        {
            tvCategoria.AllowEditing = false;

            categorias =IconUtil.ConverterL2OC(boCategoria.ObterListaCategoriadaEmpresa(frmTelaPrincipal.empLogada));
            empresas = IconUtil.ConverterL2OC(boEmpresa.ObterListaObjeto());

            //util.BestFitColumn(gcCategoria);

            habilitarBotoes(true);

            frmTelaPrincipal.tabControlMenu.IsEnabled = true;

        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            frmTelaPrincipal.tabControlMenu.IsEnabled = false;
            habilitarBotoes(false);
            tvCategoria.AddNewRow();
            tvCategoria.AllowEditing = true;
            ultimaLinhaFocada = tvCategoria.FocusedRowHandle;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var cat = gcCategoria.GetFocusedRow() as Categoria;

            boCategoria.InserirOuAlterar(cat);
            boCategoria.SaveChanges();

            MessageBox.Show("Operação Realizada com Sucesso!");

            doConsultar();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            frmTelaPrincipal.tabControlMenu.IsEnabled = false;
            ultimaLinhaFocada = tvCategoria.FocusedRowHandle;
            tvCategoria.AllowEditing = true;

            habilitarBotoes(false);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxImage icone = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show("Tem certeza que deseja excluir?", "Exclusão", MessageBoxButton.YesNo, icone);

            if (result == MessageBoxResult.Yes)
            {
                var cat = gcCategoria.GetFocusedRow() as Categoria;
                boCategoria.Excluir(cat);
                boCategoria.SaveChanges();

                doConsultar();

                MessageBox.Show("Dados removidos com sucesso!");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            doConsultar();

        }

        public void habilitarBotoes(bool enable)
        {
            btnInserir.IsEnabled = enable;
            btnAlterar.IsEnabled = enable;
            btnExcluir.IsEnabled = enable;

            btnSalvar.IsEnabled = !enable;
            btnCancelar.IsEnabled = !enable;

        }

        private void gcCategoria_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {

            var cat = gcCategoria.GetFocusedRow() as Categoria;

            int linhaFocada = tvCategoria.FocusedRowHandle;

            if (tvCategoria.AllowEditing && ultimaLinhaFocada != linhaFocada)
            {
                MessageBox.Show("Finalize a operação antes de mudar de linha!", "Operação inválida");
                tvCategoria.FocusedRowHandle = ultimaLinhaFocada;
            }

        }
    }
}

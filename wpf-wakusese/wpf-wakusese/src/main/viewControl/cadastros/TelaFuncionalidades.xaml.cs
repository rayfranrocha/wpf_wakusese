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
    /// Interaction logic for TelaFuncionalidades.xaml
    /// </summary>
    public partial class TelaFuncionalidades : UserControl
    {
        BO_Funcionalidade boFuncionalidade = (BO_Funcionalidade)FactoryBO<Funcionalidade>.GetBO();
        IconUtil util = new IconUtil();

        int ultimaLinhaFocada;// = null;
        #region DependencyProperty e ObservableCollections

        public static DependencyProperty funcionalidadesProperty = DependencyProperty.Register("funcionalidades", typeof(ObservableCollection<Funcionalidade>), typeof(TelaFuncionalidades));

        public ObservableCollection<Funcionalidade> funcionalidades
        {
            get { return (ObservableCollection<Funcionalidade>)GetValue(funcionalidadesProperty); }
            set { SetValue(funcionalidadesProperty, value); }
        }

        #endregion

        TelaPrincipal frmTelaPrincipal;
        public TelaFuncionalidades(TelaPrincipal telaPrincipalInfo)
        {
            frmTelaPrincipal = telaPrincipalInfo;
            InitializeComponent();
            funcionalidades = new ObservableCollection<Funcionalidade>();
            doConsultar();
        }

        private void doConsultar()
        {                        
            tvFuncionalidade.AllowEditing = false;
            funcionalidades = IconUtil.ConverterL2OC(boFuncionalidade.ObterListaObjeto()); 

            habilitarBotoes(true);
            frmTelaPrincipal.tabControlMenu.IsEnabled = true;
            
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            habilitarBotoes(false);
            frmTelaPrincipal.tabControlMenu.IsEnabled = false; // desabilita o tabControl - botoes principais

            tvFuncionalidade.AddNewRow();
            tvFuncionalidade.AllowEditing = true;

            ultimaLinhaFocada = tvFuncionalidade.FocusedRowHandle;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var fun = gcFuncionalidade.GetFocusedRow() as Funcionalidade;

            boFuncionalidade.InserirOuAlterar(fun);
            boFuncionalidade.SaveChanges();

            MessageBox.Show("Operação Realizada com Sucesso!");

            doConsultar();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            frmTelaPrincipal.tabControlMenu.IsEnabled = false;
            ultimaLinhaFocada = tvFuncionalidade.FocusedRowHandle;
            tvFuncionalidade.AllowEditing = true;
            habilitarBotoes(false);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxImage icone = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show("Tem certeza que deseja excluir?", "Exclusão", MessageBoxButton.YesNo, icone);

            if (result == MessageBoxResult.Yes)
            {
                var f = gcFuncionalidade.GetFocusedRow() as Funcionalidade;
                boFuncionalidade.Excluir(f);
                boFuncionalidade.SaveChanges();

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


        //Quando o foco da linha do Grid é trocado
        private void gcFuncionalidade_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            var emp = gcFuncionalidade.GetFocusedRow() as Funcionalidade;
           
            int linhaFocada = tvFuncionalidade.FocusedRowHandle;

            if (tvFuncionalidade.AllowEditing && ultimaLinhaFocada != linhaFocada)
            {
                MessageBox.Show("Finalize a operação antes de mudar de linha!", "Operação inválida");
                tvFuncionalidade.FocusedRowHandle = ultimaLinhaFocada;
            }
        }
    }
}

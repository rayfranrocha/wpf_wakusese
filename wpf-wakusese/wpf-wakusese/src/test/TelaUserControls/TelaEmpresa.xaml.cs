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

namespace wpf_wakusese.src.test.TelaUserControls
{
    /// <summary>
    /// Interaction logic for TelaEmpresa.xaml
    /// </summary>
    public partial class TelaEmpresa : UserControl
    {
        int ultimaLinhaFocada;// = null;
        BO_Empresa boEmpresa = (BO_Empresa)FactoryBO<Empresa>.GetBO();
        BO_Perfil boPerfil = (BO_Perfil)FactoryBO<Perfil>.GetBO();

       


        #region DependencyProperty e ObservableCollections

        public static DependencyProperty empresasProperty = DependencyProperty.Register("empresas", typeof(ObservableCollection<Empresa>), typeof(TelaEmpresa));

        public ObservableCollection<Empresa> empresas
        {
            get { return (ObservableCollection<Empresa>)GetValue(empresasProperty); }
            set { SetValue(empresasProperty, value); }
        }

        public static DependencyProperty perfisProperty = DependencyProperty.Register("perfis", typeof(ObservableCollection<Perfil>), typeof(TelaEmpresa));

        public ObservableCollection<Perfil> perfis
        {
            get { return (ObservableCollection<Perfil>)GetValue(perfisProperty); }
            set { SetValue(perfisProperty, value); }
        }

        public static DependencyProperty perfilFuncionalidadesProperty = DependencyProperty.Register("perfilFuncionalidades", typeof(ObservableCollection<PerfilFuncionalidade>), typeof(TelaEmpresa));

        public ObservableCollection<PerfilFuncionalidade> perfilFuncionalidades
        {
            get { return (ObservableCollection<PerfilFuncionalidade>)GetValue(perfilFuncionalidadesProperty); }
            set { SetValue(perfilFuncionalidadesProperty, value); }
        }

        ObservableCollection<Funcionalidade> listaFun = new ObservableCollection<Funcionalidade>();

        ObservableCollection<Funcionalidade> listaFuncionalidadesAtualizada = new ObservableCollection<Funcionalidade>();

        #endregion

        public TelaEmpresa()
        {
            InitializeComponent();
            empresas = new ObservableCollection<Empresa>();
            doConsultar();
        }

        private void doConsultar()
        {
            tvEmpresa.AllowEditing = false;
            tvEmpresa.IsEnabled = true;

            tvPerfil.AllowEditing = false;
            tvPerfil.IsEnabled = true;

            empresas = null;
            empresas = boEmpresa.ObterListaObjeto();

            // util.BestFitColumn(gcEmpresa);

            habilitarBotoes(true);

            btnSalvar.Visibility = Visibility.Visible;
            btnSalvarPerfil.Visibility = Visibility.Collapsed;
            btnSalvarFuncionalidadePerfil.Visibility = Visibility.Collapsed;

            gcPerfilFuncionalidade.Visibility = Visibility.Visible;
            gcPerfilFuncionalidadeLista.Visibility = Visibility.Collapsed;

        }

        public void habilitarBotoes(bool enable)
        {
            btnInserir.IsEnabled = enable;
            btnAlterar.IsEnabled = enable;
            btnExcluir.IsEnabled = enable;
            btnAddPerfil.IsEnabled = enable;
            btnAddFuncionalidadePerfil.IsEnabled = enable;

            btnSalvar.IsEnabled = !enable;
            btnSalvarPerfil.IsEnabled = !enable;
            btnCancelar.IsEnabled = !enable;

        }


        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            habilitarBotoes(false);
            if (tvEmpresa.IsEnabled)
            {
                tvEmpresa.AddNewRow();
                tvEmpresa.AllowEditing = true;
                ultimaLinhaFocada = tvEmpresa.FocusedRowHandle;
            }

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var emp = gcEmpresa.GetFocusedRow() as Empresa;

            if (emp.id == 0)
            {
                //Inserir
                boEmpresa.InserirOuAlterar(emp);
            }
            else
            {
                //Alterar
                boEmpresa.InserirOuAlterar(emp);
            }

            boEmpresa.SaveChanges();

            MessageBox.Show("Operação Realizada com Sucesso!");

            doConsultar();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            ultimaLinhaFocada = tvEmpresa.FocusedRowHandle;
            tvEmpresa.AllowEditing = true;

            habilitarBotoes(false);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxImage icone = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show("Tem certeza que deseja excluir?", "Exclusão", MessageBoxButton.YesNo, icone);

            if (result == MessageBoxResult.Yes)
            {
                var emp = gcEmpresa.GetFocusedRow() as Empresa;
                boEmpresa.Excluir(emp);
                boEmpresa.SaveChanges();

                empresas = boEmpresa.ObterListaObjeto();

                doConsultar();

                MessageBox.Show("Dados removidos com sucesso!");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            doConsultar();

        }

        private void btnAddPerfil_Click(object sender, RoutedEventArgs e)
        {
            // gcPerfil.Visibility = Visibility.Visible;


            habilitarBotoes(false);

            tvEmpresa.IsEnabled = false;
            tvPerfil.AddNewRow();
            tvPerfil.AllowEditing = true;

            ultimaLinhaFocada = tvPerfil.FocusedRowHandle;

            btnSalvarPerfil.Visibility = Visibility.Visible;
            btnSalvar.Visibility = Visibility.Collapsed;

        }

        private void btnSalvarPerfil_Click(object sender, RoutedEventArgs e)
        {
            // Pegar o perfil da linha focada
            var per = gcPerfil.GetFocusedRow() as Perfil;
            per.empresa = gcEmpresa.GetFocusedRow() as Empresa;

            boPerfil.InserirOuAlterar(per);

            //if (per.id == 0)
            //{
            //    //Inserir
                
            //}
            //else
            //{
            //    //Alterar
            //    bo.daoPerfil.Alterar(per);
            //}

            boPerfil.SaveChanges();

            MessageBox.Show("Operação Realizada com Sucesso!");

            doConsultar();
        }

        //Quando o foco da linha do GridEmpresa é trocado
        private void gcEmpresa_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            var emp = gcEmpresa.GetFocusedRow() as Empresa;
            perfis = new ObservableCollection<Perfil>();
            perfis = boPerfil.ObterListaEmpresaPerfil(emp);

            int linhaFocada = tvEmpresa.FocusedRowHandle;

            if (tvEmpresa.AllowEditing && ultimaLinhaFocada != linhaFocada)
            {
                MessageBox.Show("Finalize a operação antes de mudar de linha!", "Operação inválida");
                tvEmpresa.FocusedRowHandle = ultimaLinhaFocada;
            }
        }

        //Quando o foco da linha do GridPerfil é trocado
        private void gcPerfil_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            BO_PerfilFuncionalidade boPerfilFuncionalidade = (BO_PerfilFuncionalidade)FactoryBO<PerfilFuncionalidade>.GetBO();
            int linhaFocada = tvPerfil.FocusedRowHandle;

            if (tvPerfil.AllowEditing && ultimaLinhaFocada != linhaFocada)
            {
                MessageBox.Show("Finalize a operação antes de mudar de linha!", "Operação inválida");
                tvPerfil.FocusedRowHandle = ultimaLinhaFocada;
            }

            var per = gcPerfil.GetFocusedRow() as Perfil;
            if (per != null && perfis.Count != 0)
            {
                perfilFuncionalidades = new ObservableCollection<PerfilFuncionalidade>();
                perfilFuncionalidades = boPerfilFuncionalidade.ObterListaFuncinalidadedoPerfilSelecionado(per);
                btnAddFuncionalidadePerfil.IsEnabled = true;
            }
            else
            {
                perfilFuncionalidades = null;
                btnAddFuncionalidadePerfil.IsEnabled = false;

            }


        }

        private void btnAddFuncionalidadePerfil_Click(object sender, RoutedEventArgs e)
        {
            BO_Funcionalidade boFuncionalidade = (BO_Funcionalidade)FactoryBO<Funcionalidade>.GetBO();

            gcPerfilFuncionalidade.Visibility = Visibility.Collapsed;
            gcPerfilFuncionalidadeLista.Visibility = Visibility.Visible;

            btnSalvar.Visibility = Visibility.Collapsed;
            btnSalvarPerfil.Visibility = Visibility.Collapsed;
            btnSalvarFuncionalidadePerfil.Visibility = Visibility.Visible;

            tvEmpresa.IsEnabled = false;
            tvPerfil.IsEnabled = false;
            tvPerfil.AllowEditing = true;

            habilitarBotoes(false);

            var listaPerfilFuncionalidadeSelecionado = perfilFuncionalidades as ObservableCollection<PerfilFuncionalidade>;

            // Obter a Lista de todas as funcionalidades Cadastradas
            listaFuncionalidadesAtualizada = boFuncionalidade.ObterListaObjeto();

            foreach (var itemFuncionalidade in listaFuncionalidadesAtualizada)
            {
                itemFuncionalidade.isSelecionado = false;

                foreach (var itemPerfilFuncionalidade in listaPerfilFuncionalidadeSelecionado)
                {
                    if (itemPerfilFuncionalidade.funcionalidade.id == itemFuncionalidade.id)
                    {
                        itemFuncionalidade.isSelecionado = true;
                    }
                }
            }


            gcPerfilFuncionalidadeLista.ItemsSource = listaFuncionalidadesAtualizada;

            //perfilFuncionalidades = listaFuncionalidadesAtualizada;

        }

        private void btnSalvarFuncionalidadePerfil_Click(object sender, RoutedEventArgs e)
        {
            BO_PerfilFuncionalidade boPerfilFuncionalidade = (BO_PerfilFuncionalidade)FactoryBO<PerfilFuncionalidade>.GetBO();

            btnSalvar.Visibility = Visibility.Visible;
            btnSalvarPerfil.Visibility = Visibility.Visible;
            btnSalvarFuncionalidadePerfil.Visibility = Visibility.Collapsed;

            var listaPerfilFuncionalidadeSelecionado = perfilFuncionalidades as ObservableCollection<PerfilFuncionalidade>;

            bool exc;

            for (int i = 0; i < listaFuncionalidadesAtualizada.Count; i++)
            {
                exc = false;
                for (int l = 0; l < listaPerfilFuncionalidadeSelecionado.Count; l++)
                {
                    if (!listaFuncionalidadesAtualizada[i].isSelecionado && listaFuncionalidadesAtualizada[i].id == listaPerfilFuncionalidadeSelecionado[l].funcionalidade.id)
                    {

                        boPerfilFuncionalidade.Excluir(listaPerfilFuncionalidadeSelecionado[l]);
                        listaPerfilFuncionalidadeSelecionado.Remove(listaPerfilFuncionalidadeSelecionado[l]);
                        exc = true;
                    }
                    else if (listaFuncionalidadesAtualizada[i].isSelecionado && listaFuncionalidadesAtualizada[i].id == listaPerfilFuncionalidadeSelecionado[l].funcionalidade.id)
                    {
                        exc = true;
                    }
                }


                if (listaFuncionalidadesAtualizada[i].isSelecionado && exc == false)
                {
                    PerfilFuncionalidade pf = new PerfilFuncionalidade();
                    pf.funcionalidade = listaFuncionalidadesAtualizada[i];
                    pf.perfil = gcPerfil.GetFocusedRow() as Perfil;
                    boPerfilFuncionalidade.InserirOuAlterar(pf);
                }
            }

            boPerfilFuncionalidade.SaveChanges();
            doConsultar();


        }
        
        


    }
}

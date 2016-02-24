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
using wpf_wakusese.src.main.model.servicos;

namespace wpf_wakusese.src.main.viewControl.cadastros
{
    /// <summary>
    /// Interaction logic for TelaUsuarios.xaml
    /// </summary>
    public partial class TelaUsuarios : UserControl
    {
        
        BO_Usuario boUsuario = (BO_Usuario)FactoryBO<Usuario>.GetBO();
        BO_UsuarioPerfil boUsuarioPerfil = (BO_UsuarioPerfil)FactoryBO<UsuarioPerfil>.GetBO();
        IconUtil util = new IconUtil();
        DominioSeguranca domSeguranca = new DominioSeguranca();

        int ultimaLinhaFocada = 0;

        #region DependecyPropertys and ObservableCollecions

        ObservableCollection<Perfil> listaPerfisAtualizada = new ObservableCollection<Perfil>();

        public static DependencyProperty usuariosProperty = DependencyProperty.Register("usuarios", typeof(ObservableCollection<Usuario>), typeof(TelaUsuarios));

        public ObservableCollection<Usuario> usuarios
        {
            get { return (ObservableCollection<Usuario>)GetValue(usuariosProperty); }
            set { SetValue(usuariosProperty, value); }
        }

        public static DependencyProperty empresasProperty = DependencyProperty.Register("empresas", typeof(ObservableCollection<Empresa>), typeof(TelaUsuarios));

        public ObservableCollection<Empresa> empresas
        {
            get { return (ObservableCollection<Empresa>)GetValue(empresasProperty); }
            set { SetValue(empresasProperty, value); }
        }

        public static DependencyProperty perfisProperty = DependencyProperty.Register("perfis", typeof(ObservableCollection<Perfil>), typeof(TelaUsuarios));

        public ObservableCollection<Perfil> perfis
        {
            get { return (ObservableCollection<Perfil>)GetValue(perfisProperty); }
            set { SetValue(perfisProperty, value); }
        }

        public static DependencyProperty usuarioPerfisProperty = DependencyProperty.Register("usuarioPerfis", typeof(ObservableCollection<UsuarioPerfil>), typeof(TelaUsuarios));

        public ObservableCollection<UsuarioPerfil> usuarioPerfis
        {
            get { return (ObservableCollection<UsuarioPerfil>)GetValue(usuarioPerfisProperty); }
            set { SetValue(usuarioPerfisProperty, value); }
        }

        public static DependencyProperty perfilFuncionalidadesProperty = DependencyProperty.Register("perfilFuncionalidades", typeof(ObservableCollection<PerfilFuncionalidade>), typeof(TelaUsuarios));

        public ObservableCollection<PerfilFuncionalidade> perfilFuncionalidades
        {
            get { return (ObservableCollection<PerfilFuncionalidade>)GetValue(perfilFuncionalidadesProperty); }
            set { SetValue(perfilFuncionalidadesProperty, value); }
        }

        #endregion

        Empresa emp = new Empresa();

        TelaPrincipal frmTelaPrincipal;
        public TelaUsuarios(TelaPrincipal telaPrincipalInfo)
        {
            InitializeComponent();
            
            frmTelaPrincipal = telaPrincipalInfo;
            
            usuarios = new ObservableCollection<Usuario>();
            perfilFuncionalidades = new ObservableCollection<PerfilFuncionalidade>();
            perfis = new ObservableCollection<Perfil>();

            BO_Empresa boEmpresa = (BO_Empresa)FactoryBO<Empresa>.GetBO();
            emp = boEmpresa.ObterEmpresaPorId(frmTelaPrincipal.empLogada.id);

            doConsultar();
        }

        private void doConsultar()
        {
            btnSalvar.Visibility = Visibility.Visible;
            btnSalvarUsuarioPerfil.Visibility = Visibility.Collapsed;

            lPGcPerfilFuncionalidades.Visibility = Visibility.Visible;
            lPGcPerfil.Visibility = Visibility.Hidden;

            tvUsuario.IsEnabled = true;
            tvUsuario.AllowEditing = false;

            tvPerfilEmpresa.IsEnabled = true; //tvUsuarioPerfil.IsEnabled = true;       

            usuarios = IconUtil.ConverterL2OC(domSeguranca.ObterListaUsuariodaEmpresa(emp));

            //util.BestFitColumn(gcUsuario);

            habilitarBotoes(true);

            frmTelaPrincipal.tabControlMenu.IsEnabled = true;

        }

        #region Botoes_clicks

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            //frmTelaPrincipal.tabControlMenu.IsEnabled = false;
            //habilitarBotoes(false);

            //if (tvUsuario.IsEnabled)
            //{
            //    tvUsuario.AddNewRow();
            //    tvUsuario.AllowEditing = true;
            //    ultimaLinhaFocada = tvUsuario.FocusedRowHandle;

            //}
            PopupInserirUsuario frm = new PopupInserirUsuario();
            frm.ShowDialog();

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var usu = gcUsuario.GetFocusedRow() as Usuario;

            boUsuario.InserirOuAlterar(usu);
            boUsuario.SaveChanges();

            MessageBox.Show("Operação Realizada com Sucesso!");

            doConsultar();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            frmTelaPrincipal.tabControlMenu.IsEnabled = false;
            ultimaLinhaFocada = tvUsuario.FocusedRowHandle;
            tvUsuario.AllowEditing = true;

            habilitarBotoes(false);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxImage icone = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show("Tem certeza que deseja excluir?", "Exclusão", MessageBoxButton.YesNo, icone);

            if (result == MessageBoxResult.Yes)
            {
                var usu = gcUsuario.GetFocusedRow() as Usuario;
                boUsuario.Excluir(usu);
                boUsuario.SaveChanges();

                usuarios = IconUtil.ConverterL2OC(boUsuario.ObterListaObjeto()); ///

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
            frmTelaPrincipal.tabControlMenu.IsEnabled = false;
            tvUsuario.IsEnabled = false;
            tvPerfilEmpresa.IsEnabled = false; //tvUsuarioPerfil.IsEnabled = false; 

            btnSalvar.Visibility = Visibility.Collapsed;
            btnSalvarUsuarioPerfil.Visibility = Visibility.Visible;

            lPGcPerfilFuncionalidades.Visibility = Visibility.Collapsed;
            lPGcPerfil.Visibility = Visibility.Visible;

            habilitarBotoes(false);

            //perfis = bo.daoPerfil.ObterListaObjeto();

            BO_Perfil boPerfil = (BO_Perfil)FactoryBO<Perfil>.GetBO();
            var listaUsuarioPerfis = usuarioPerfis as ObservableCollection<UsuarioPerfil>;

            // Obter a Lista de todas as funcionalidades Cadastradas
            listaPerfisAtualizada = IconUtil.ConverterL2OC(boPerfil.ObterListaObjeto());

            foreach (var itemPerfil in listaPerfisAtualizada)
            {
                itemPerfil.isSelecionado = false;

                foreach (var itemUsuarioPerfil in listaUsuarioPerfis)
                {
                    if (itemUsuarioPerfil.perfil.id == itemPerfil.id)
                    {
                        itemPerfil.isSelecionado = true;
                    }
                }
            }

            gcPerfil.ItemsSource = listaPerfisAtualizada;

        }

        private void btnSalvarUsuarioPerfil_Click(object sender, RoutedEventArgs e)
        {

            var listaUsuarioPerfis = usuarioPerfis as ObservableCollection<UsuarioPerfil>;

            bool exc;

            for (int i = 0; i < listaPerfisAtualizada.Count; i++)
            {
                exc = false;
                for (int l = 0; l < listaUsuarioPerfis.Count; l++)
                {
                    if (!listaPerfisAtualizada[i].isSelecionado && listaPerfisAtualizada[i].id == listaUsuarioPerfis[l].perfil.id)
                    {

                        boUsuarioPerfil.Excluir(listaUsuarioPerfis[l]);
                        listaUsuarioPerfis.Remove(listaUsuarioPerfis[l]);
                        boUsuarioPerfil.SaveChanges();
                        exc = true;
                    }
                    else if (listaPerfisAtualizada[i].isSelecionado && listaPerfisAtualizada[i].id == listaUsuarioPerfis[l].perfil.id)
                    {
                        exc = true;
                    }
                }

                if (listaPerfisAtualizada[i].isSelecionado && exc == false)
                {
                    UsuarioPerfil usuPer = new UsuarioPerfil();
                    usuPer.usuario = gcUsuario.GetFocusedRow() as Usuario;
                    usuPer.perfil = listaPerfisAtualizada[i];
                    boUsuarioPerfil.InserirOuAlterar(usuPer);
                    boUsuarioPerfil.SaveChanges();
                }
            }

            doConsultar();
        }

        #endregion

        public void habilitarBotoes(bool enable)
        {

            btnInserir.IsEnabled = enable;
            btnAlterar.IsEnabled = enable;
            btnExcluir.IsEnabled = enable;
            btnAddPerfil.IsEnabled = enable;

            btnSalvar.IsEnabled = !enable;
            btnCancelar.IsEnabled = !enable;

        }

        private void gcUsuario_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            var usuFocado = gcUsuario.GetFocusedRow() as Usuario;

            BO_Perfil boPerfil = (BO_Perfil)FactoryBO<Perfil>.GetBO();
            BO_Empresa boEmpresa = (BO_Empresa)FactoryBO<Empresa>.GetBO();
            boEmpresa.Attach(emp); //  Antes a empresas estava utiliazando para um endereço "new" automatico///////////////////////////////////////////////////////////////////////////////////////

            //Preenche o Grid control Usuario perfil de acordo com o usuario linha focada
            usuarioPerfis = new ObservableCollection<UsuarioPerfil>();
            usuarioPerfis = IconUtil.ConverterL2OC(boUsuarioPerfil.ObterListaObjetoUsuario(usuFocado));

            ObservableCollection<Perfil> listaPerfil = new ObservableCollection<Perfil>();

            if (usuarioPerfis != null)
            {
                foreach (var item in usuarioPerfis)
                {
                    listaPerfil.Add(boPerfil.ObterPerfil(item));
                }

                //gcPerfilEmpresa.ItemsSource = listaPerfil;
                perfis = listaPerfil;
            }

            int linhaFocada = tvUsuario.FocusedRowHandle;

            if (tvUsuario.AllowEditing && ultimaLinhaFocada != linhaFocada)
            {
                MessageBox.Show("Finalize a operação antes de mudar de linha!", "Operação inválida");
                tvUsuario.FocusedRowHandle = ultimaLinhaFocada;
            }
        }

        private void gcPerfilEmpresa_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            BO_PerfilFuncionalidade boPerfilFuncionalidade = (BO_PerfilFuncionalidade)FactoryBO<PerfilFuncionalidade>.GetBO();
            var per = gcPerfilEmpresa.GetFocusedRow() as Perfil;
            if (per != null && perfis.Count != 0)
            {
                perfilFuncionalidades = new ObservableCollection<PerfilFuncionalidade>();
                perfilFuncionalidades = IconUtil.ConverterL2OC(boPerfilFuncionalidade.ObterListaFuncinalidadedoPerfilSelecionado(per));

            }
            else
            {
                perfilFuncionalidades = null;

            }
        }
    }
}

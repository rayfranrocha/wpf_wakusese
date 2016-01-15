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
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpf_wakusese.model;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.cadastros.bo;

namespace wpf_wakusese
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //BoPadrao<Funcionalidade> boFuncionalidade = FactoryBO  BoPadrao<Funcionalidade>.GetInstance();
        //BoPadrao<Empresa> boEmpresa= BoPadrao<Empresa>.GetInstance();

        public MainWindow()
        {
            InitializeComponent();

            //Este bo possui uma classe BOEmpresa
            BOEmpresa boEmpresa = (BOEmpresa) FactoryBO.GetBO(typeof(Empresa));

            //Neste BO, eu não fiz uma classe, portanto deveriamos criar um BoGenerico -> BoPadrao<Funcionalidade>
            //Não consegui.
            //BoPadrao<Funcionalidade> boFunc = (BoPadrao<Funcionalidade>)FactoryBO.GetBO(typeof(Funcionalidade));

        }

        //private void incluirEmpresaEPerfil()
        //{
        //    Empresa emp = new Empresa() { nome = "Grupo Simões" };
        //    Perfil p1 = new Perfil() { empresa = emp, nome = "PROGRAMADOR" };
        //    Perfil p2 = new Perfil() { empresa = emp, nome = "ANALISTA" };
        //    Perfil p3 = new Perfil() { empresa = emp, nome = "GERENTE" };

        //    bo.daoEmpresa.Inserir(emp);
        //    bo.daoPerfil.Inserir(p1);
        //    bo.daoPerfil.Inserir(p2);
        //    bo.daoPerfil.Inserir(p3);

        //    bo.Commit();

        //}

        //private void incluirPerfil_entityStub()
        //{
        //    Empresa emp = new Empresa() { id = 1 };
        //    bo.daoEmpresa.AttachTo(emp);

        //    Perfil p = new Perfil() { empresa = emp, nome = "ANALISTA" };

        //    bo.daoPerfil.Inserir(p);
        //    bo.Commit();

        //}

        //private void incluirEmpresa()
        //{
        //    Empresa emp = new Empresa();
        //    emp.nome = "ICON";
        //    bo.daoEmpresa.Inserir(emp);
        //    bo.Commit();
        //}
    }
}

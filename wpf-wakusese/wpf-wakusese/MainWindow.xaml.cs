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
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.cadastros.bo;
using wpf_wakusese.src.main.model.cadastros.ce;
using wpf_wakusese.src.main.model.seguranca.bo;
using wpf_wakusese.src.main.model.seguranca.ce;

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

            //Exemplo2(boUsuario);
            //Exemplo3();
            //Exemplo4();
            //Exemplo5();
            //Exemplo6();
            //Exemplo7();
            //Exemplo8();
            //Exemplo9();
            //Exemplo10();
            //Exemplo11();
            //Exemplo12();
            //Exemplo13();
            //Exemplo14();
            Exemplo15();

        }

        private void Exemplo15()
        {
            BOUsuario boUsuario = (BOUsuario)FactoryBO.GetBO(typeof(Usuario));
            Usuario u1 = new Usuario() { id = 15, macTelefone = "559291222093" };
            Usuario u2 = new Usuario() { macTelefone = "000000000000" , email="teste"};

            boUsuario.InserirOuAlterar(u2);
            boUsuario.AlterarCamposEpecificos(u1, new[] { "macTelefone" });

            boUsuario.Commit();
        }

        private void Exemplo14()
        {
            BOUsuario boUsuario = (BOUsuario)FactoryBO.GetBO(typeof(Usuario));
            Usuario u1 = new Usuario() { id = 15, macTelefone = "559291222093" };
            Usuario u2 = new Usuario() { macTelefone = "000000000000" };
            
            boUsuario.InserirOuAlterar(u2);
            boUsuario.AlterarCamposEpecificos(u1, new[] { "macTelefone" });

            boUsuario.Commit();
        }

        private void Exemplo13()
        {
            BOUsuario boUsuario = (BOUsuario)FactoryBO.GetBO(typeof(Usuario));
            Usuario u1 = new Usuario() { id = 15, macTelefone = "559291222093" };
            boUsuario.AlterarCamposEpecificos(u1, new[] { "macTelefone" });
            boUsuario.Commit();
        }

        private void Exemplo12()
        {
            BOUsuario boUsuario = (BOUsuario)FactoryBO.GetBO(typeof(Usuario));
            Usuario u1 = new Usuario() { id=15, email="aaaaaaaaaaaaa", macTelefone = "10000"};
            boUsuario.AlterarCamposEpecificos(u1, new[] { "email", "macTelefone" });
            boUsuario.Commit();
        }

        private void Exemplo11()
        {
            BOUsuario boUsuario = (BOUsuario)FactoryBO.GetBO(typeof(Usuario));
            Usuario u1 = new Usuario() { macTelefone="222", email="luiz.gonzaga@gmail.com", senha = "123" };
            boUsuario.InserirOuAlterar(u1);
            boUsuario.Commit();
        }

        private void Exemplo10()
        {
            BOUsuario boUsuario = (BOUsuario)FactoryBO.GetBO(typeof(Usuario));
            Usuario u1 = new Usuario() { email = "b1" };
            boUsuario.InserirOuAlterar(u1);
            boUsuario.Commit();
        }

        private void Exemplo9()
        {
            BOUsuario boUsuario = (BOUsuario)FactoryBO.GetBO(typeof(Usuario));
            Usuario u1 = new Usuario() { email = "a1" };
            Usuario u2 = new Usuario() { email = "a2" };
            Usuario u3 = new Usuario() { email = "a3" };
            Usuario u4 = new Usuario() { email = "a4" };
            Usuario u5 = new Usuario() { email = "a5" };
            Usuario u6 = new Usuario() { email = "a6" };

            boUsuario.InserirOuAlterar(u1);
            boUsuario.InserirOuAlterar(u2);
            boUsuario.InserirOuAlterar(u3);
            boUsuario.InserirOuAlterar(u4);

            boUsuario.Excluir(u2);

            boUsuario.InserirOuAlterar(u5);
            boUsuario.InserirOuAlterar(u6);

            boUsuario.Commit();
        }

        private void Exemplo8()
        {
            BOUsuario boUsuario = (BOUsuario)FactoryBO.GetBO(typeof(Usuario));
            Usuario u = new Usuario() { email = "zitronavi@gmail.com" };
            boUsuario.Excluir(u);
            boUsuario.Commit();            
        }

        private void Exemplo7()
        {
            BOUsuario boUsuario = (BOUsuario)FactoryBO.GetBO(typeof(Usuario));
            Usuario u = boUsuario.ObterPrimeiro(2);
            u.senha = "555";
            boUsuario.InserirOuAlterar(u);
            boUsuario.Commit();
        }

        private void Exemplo6()
        {
            BOUsuario boUsuario = (BOUsuario)FactoryBO.GetBO(typeof(Usuario));
            Usuario u = new Usuario() { id = 2, senha = "4444" };
            boUsuario.InserirOuAlterar(u);
            boUsuario.Commit();
        }

        private void Exemplo5()
        {
            BOUsuario boUsuario = (BOUsuario)FactoryBO.GetBO(typeof(Usuario));

            Usuario usu1 = new Usuario() { email = "fco.queiroz@gmail.com" };
            Usuario usu2 = new Usuario() { email = "zitronavi@gmail.com" };
            Usuario usu3 = new Usuario() { email = "thayan.jones@gmail.com" };

            List<Usuario> listaUsuario = new List<Usuario>();
            listaUsuario.Add(usu1);
            listaUsuario.Add(usu2);
            listaUsuario.Add(usu3);

            boUsuario.InserirOuAlterar(listaUsuario);

            boUsuario.Commit();

            listaUsuario = boUsuario.ObterListaObjeto().ToList();

        }

        private static void Exemplo4()
        {
            BOUsuario boUsuario = new BOUsuario();
            Usuario usu = new Usuario() { email = "alguem.da.google@google.com" };
            Empresa emp = new Empresa() { nome = "Google" };
            boUsuario.ExemploVerificaUsuarioEmpresa_seNaoExistir_CriaOsDois(usu, emp);
        }

        private static void Exemplo3()
        {
            //Neste BO, eu não fiz uma classe, portanto deveriamos criar um BoGenerico -> BoPadrao<Funcionalidade>
            //Não consegui.
            BoPadrao<Funcionalidade> boFunc = (BoPadrao<Funcionalidade>)FactoryBO.GetBO(typeof(Funcionalidade));
        }

        private static void Exemplo2(BOUsuario boUsuario)
        {
            BOUsuario boUsuario1 = new BOUsuario();

            Usuario u = new Usuario() { email = "rayfran.rocha.lima@gmail.com", senha = "123" };

            boUsuario1.InserirOuAlterar(u);

            boUsuario1.Commit();
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

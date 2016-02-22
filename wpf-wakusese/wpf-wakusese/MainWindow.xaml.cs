using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using wpf_wakusese.src.main.model.servicos;
using wpf_wakusese.src.main.model.bo;
using wpf_wakusese.src.main.model.ce;
using System.Collections.ObjectModel;

namespace wpf_wakusese
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IconUtil util = new IconUtil();
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
            //Exemplo15();
            //Exemplo16();
            //Exemplo17_SQLNativo();
            //Exemplo18_SQLNativo();
            //Exemplo19();
            //Exemplo20();
            //Exemplo21();
            //Exemplo22();
            //Exemplo23();
            //Exemplo25();
            //Exemplo26();
            //Exemplo27();
            //Exemplo28(); //FactoryBO
            Exemplo29(); //Teste de singleto do FactoryBO
        }

        private void Exemplo29()
        {

            var bo1 = FactoryBO<Empresa>.GetBO();
            var bo2 = FactoryBO<Empresa>.GetBO();

            Empresa emp = new Empresa() { nome = "ICON Solucoes" };
            bo1.InserirOuAlterar(emp);

            bo2.SaveChanges();

            bool singleton = bo1 == bo2;
            
        }

        private void Exemplo28()
        {
            //var bo1 = new BO_Empresa();
            //ObservableCollection<Empresa> lista1 = bo1.ObterListaObjeto();

            var bo2 = FactoryBO<Empresa>.GetBO();
            ObservableCollection<Empresa> lista2 = util.ConverterL2OC(bo2.ObterListaObjeto());
        }

        private void Exemplo27()
        {
            //DominioSeguranca ds = new DominioSeguranca();
            //ds.doAutenticarUsuario();
        }

        private void Exemplo26()
        {
            //using (var boPerfil = new BO_Perfil( new EFDBContext() ))
            //{

            //    Perfil p = boPerfil.ObterObjetoPorId(1);

            //}            
        }

        private void Exemplo25()
        {
            //using (var ctx = new EFDBContext())
            //{
            //    BO_Perfil boPerfil = new BO_Perfil(ctx);

            //    Empresa emp = new Empresa() { id = 1 };
            //    boPerfil.InserirOuAlterar(new Perfil() { empresa = emp, nome = "Garçom Padrao Enum", perfilPadraoEnum = src.main.model.enums.PerfilPadraoEnum.Garcom });
            //    boPerfil.SaveChanges();
            //}
        }

        private void Exemplo23()
        {
            //using (var ctx = new EFDBContext())
            //{
            //    BO_Usuario boUsuario = new BO_Usuario(ctx);
            //    var xxx = boUsuario.ObterListaObjeto();
            //}
        }

        private void Exemplo22()
        {
            //using (var context = new EFDBContext())
            //{
            //    BO_Usuario boUsuario = new BO_Usuario(context);
            //    Usuario u = boUsuario.ObterObjetoPorId(13);
            //}
        }

        private void Exemplo21()
        {
            //GenericoBO<Funcionalidade> funcionalidadeServico = new GenericoBO<Funcionalidade>();
            //for (int i = 0; i < 10; i++)
            //{
            //    Funcionalidade f1 = new Funcionalidade() { nome = "login" + i };
            //    funcionalidadeServico.InserirOuAlterar(f1);
            //}
            //funcionalidadeServico.SaveChanges();
            //var lf = funcionalidadeServico.ObterListaObjeto();
        }

        private void Exemplo20()
        {
            //using (var context = new EFDBContext())
            //{
            //    //UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));
            //    //Usuario u = boUsuario.ObterObjetoPorId(13);
            //}
        }

        //private void Exemplo18_SQLNativo()
        //{
        //    //UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));

        //    //boUsuario.AlterarCamposEpecificos(new Usuario(), "campo1", "campo2");
        //}

        //private void Exemplo19()
        //{
        //    using (var context = new EFDBContext())
        //    {
        //        var listaEmails = context.Database.SqlQuery<string>("SELECT email FROM tb_usuario").ToList();
        //        int totalUsuarios = Convert.ToInt32(context.Database.SqlQuery<string>("SELECT count(*) FROM tb_usuario").ToList()[0]);
        //    }
        //}

        //private void Exemplo17_SQLNativo()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));

        //    //sql + 0 parametro
        //    var lista1 = boUsuario.ObterListaBySQLNativo("select * from tb_usuario u", new object[] { }).ToList();

        //    //sql + 1 parametro
        //    var lista2 = boUsuario.ObterListaBySQLNativo("select * from tb_usuario u where u.email = :email",
        //                                      new object[] { new NpgsqlParameter(":email", "rayfran.rocha.lima@gmail.com") }
        //                                    ).ToList();

        //    //sql + N parametros
        //    string sql = "select * from tb_usuario u where u.email = :email and u.senha = :senha";
        //    object[] parametros = new object[] { new NpgsqlParameter(":email", "rayfran.rocha.lima@gmail.com")
        //                                       , new NpgsqlParameter(":senha", "123")};

        //    var lista3 = boUsuario.ObterListaBySQLNativo(sql, parametros).ToList();
        //}

        //private void Exemplo16()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));

        //    IEnumerable<Usuario> listaUsuario = boUsuario.ObterListaByQuery(o => o.email != null, o => o.OrderBy(u => u.email), "ultimaEmpresa");

        //}

        //private void Exemplo15()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));
        //    Usuario u1 = new Usuario() { id = 15, macTelefone = "559291222093" };
        //    Usuario u2 = new Usuario() { macTelefone = "000000000000", email = "teste" };

        //    boUsuario.InserirOuAlterar(u2);
        //    boUsuario.AlterarCamposEpecificos(u1, "macTelefone");

        //    boUsuario.SaveChanges();
        //}

        //private void Exemplo14()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));
        //    Usuario u1 = new Usuario() { id = 15, macTelefone = "559291222093" };
        //    Usuario u2 = new Usuario() { macTelefone = "000000000000" };

        //    boUsuario.InserirOuAlterar(u2);
        //    boUsuario.AlterarCamposEpecificos(u1, "macTelefone");

        //    boUsuario.SaveChanges();

        //}

        //private void Exemplo13()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));
        //    Usuario u1 = new Usuario() { id = 15, macTelefone = "559291222093" };
        //    boUsuario.AlterarCamposEpecificos(u1, "macTelefone");
        //    boUsuario.SaveChanges();
        //}

        //private void Exemplo12()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));
        //    Usuario u1 = new Usuario() { id = 15, email = "aaaaaaaaaaaaa", macTelefone = "10000" };
        //    boUsuario.AlterarCamposEpecificos(u1, "email", "macTelefone");
        //    boUsuario.SaveChanges();
        //}

        //private void Exemplo11()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));
        //    Usuario u1 = new Usuario() { macTelefone = "222", email = "luiz.gonzaga@gmail.com", senha = "123" };
        //    boUsuario.InserirOuAlterar(u1);
        //    boUsuario.SaveChanges();
        //}

        //private void Exemplo10()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));
        //    Usuario u1 = new Usuario() { email = "b1" };
        //    boUsuario.InserirOuAlterar(u1);
        //    boUsuario.SaveChanges();
        //}

        //private void Exemplo9()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));
        //    Usuario u1 = new Usuario() { email = "a1" };
        //    Usuario u2 = new Usuario() { email = "a2" };
        //    Usuario u3 = new Usuario() { email = "a3" };
        //    Usuario u4 = new Usuario() { email = "a4" };
        //    Usuario u5 = new Usuario() { email = "a5" };
        //    Usuario u6 = new Usuario() { email = "a6" };

        //    boUsuario.InserirOuAlterar(u1);
        //    boUsuario.InserirOuAlterar(u2);
        //    boUsuario.InserirOuAlterar(u3);
        //    boUsuario.InserirOuAlterar(u4);

        //    boUsuario.Excluir(u2);

        //    boUsuario.InserirOuAlterar(u5);
        //    boUsuario.InserirOuAlterar(u6);

        //    boUsuario.SaveChanges();
        //}

        //private void Exemplo8()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));
        //    Usuario u = new Usuario() { email = "zitronavi@gmail.com" };
        //    boUsuario.Excluir(u);
        //    boUsuario.SaveChanges();
        //}

        //private void Exemplo7()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));
        //    Usuario u = boUsuario.ObterPrimeiro(2);
        //    u.senha = "555";
        //    boUsuario.InserirOuAlterar(u);
        //    boUsuario.SaveChanges();
        //}

        //private void Exemplo6()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));
        //    Usuario u = new Usuario() { id = 2, senha = "4444" };
        //    boUsuario.InserirOuAlterar(u);
        //    boUsuario.SaveChanges();
        //}

        //private void Exemplo5()
        //{
        //    UsuarioBO boUsuario = (UsuarioBO)FactoryBO.GetServico(typeof(Usuario));

        //    Usuario usu1 = new Usuario() { email = "fco.queiroz@gmail.com" };
        //    Usuario usu2 = new Usuario() { email = "zitronavi@gmail.com" };
        //    Usuario usu3 = new Usuario() { email = "thayan.jones@gmail.com" };

        //    List<Usuario> listaUsuario = new List<Usuario>();
        //    listaUsuario.Add(usu1);
        //    listaUsuario.Add(usu2);
        //    listaUsuario.Add(usu3);

        //    boUsuario.InserirOuAlterar(listaUsuario);

        //    boUsuario.SaveChanges();

        //    listaUsuario = boUsuario.ObterListaObjeto().ToList();

        //}

        //private static void Exemplo4()
        //{
        //    SegurancaServico segurancaServico = new SegurancaServico();

        //    Usuario usu = new Usuario() { email = "alguem.da.google@google.com" };
        //    Empresa emp = new Empresa() { nome = "Google" };
        //    segurancaServico.ExemploVerificaUsuarioEmpresa_seNaoExistir_CriaOsDo1is(usu, emp);
        //}

        //private static void Exemplo3()
        //{
        //    //Neste BO, eu não fiz uma classe, portanto deveriamos criar um BoGenerico -> BoPadrao<Funcionalidade>
        //    //Não consegui.
        //    GenericoBO<Funcionalidade> boFunc = (GenericoBO<Funcionalidade>)FactoryBO.GetServico(typeof(Funcionalidade));
        //}

        //private static void Exemplo2(UsuarioBO boUsuario)
        //{
        //    UsuarioBO boUsuario1 = new UsuarioBO();

        //    Usuario u = new Usuario() { email = "rayfran.rocha.lima@gmail.com", senha = "123" };

        //    boUsuario1.InserirOuAlterar(u);

        //    boUsuario1.SaveChanges();
        //}

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

        //    bo.SaveChanges();

        //}

        //private void incluirPerfil_entityStub()
        //{
        //    Empresa emp = new Empresa() { id = 1 };
        //    bo.daoEmpresa.AttachTo(emp);

        //    Perfil p = new Perfil() { empresa = emp, nome = "ANALISTA" };

        //    bo.daoPerfil.Inserir(p);
        //    bo.SaveChanges();

        //}

        //private void incluirEmpresa()
        //{
        //    Empresa emp = new Empresa();
        //    emp.nome = "ICON";
        //    bo.daoEmpresa.Inserir(emp);
        //    bo.SaveChanges();
        //}
    }
}

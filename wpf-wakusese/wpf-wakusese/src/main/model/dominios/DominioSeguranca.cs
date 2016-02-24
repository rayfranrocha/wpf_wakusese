using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.bo;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.model.servicos
{
    public class DominioSeguranca
    {
        private EFDBContext dbContext;

        private BO_Usuario boUsuario;
        private BO_Empresa boEmpresa;
        private BO_UsuarioPerfil boUsuarioPerfil;
        private BO_PerfilFuncionalidade boPerfilFuncionalidade;
        private BO_Perfil boPerfil;

        public DominioSeguranca()
        {
            dbContext = EFDBContext.Instance;
            boUsuario = (BO_Usuario)FactoryBO<Usuario>.GetBO();
            boEmpresa = (BO_Empresa)FactoryBO<Empresa>.GetBO();
            boUsuarioPerfil = (BO_UsuarioPerfil)FactoryBO<UsuarioPerfil>.GetBO();
            boPerfilFuncionalidade = (BO_PerfilFuncionalidade)FactoryBO<PerfilFuncionalidade>.GetBO();
            boPerfil = (BO_Perfil)FactoryBO<Perfil>.GetBO();
        }

        public void ExemploVerificaUsuarioEmpresa_seNaoExistir_CriaOsDois(Usuario usu, Empresa emp)
        {

            try
            {

                Usuario usuario = boUsuario.ObterPrimeiro(x => x.email == usu.email);
            }
            catch (Exception)
            {
                boUsuario.InserirOuAlterar(usu);
            }

            try
            {
                Empresa empresa = boEmpresa.ObterPrimeiro(x => x.nome == emp.nome);
            }
            catch (Exception)
            {
                boEmpresa.InserirOuAlterar(emp);
            }

            dbContext.SaveChanges();

        }

        /// <summary>
        /// Este método é resposável por autenticar um usuario (fazer login e recuperar seus acessos)
        /// <para> 1. Obtem o usuario a partir das credenciais do usuário (telefone ou email + senha). Este usuario deve conter UltimaEmpresa </para>
        /// <para> 2. Define lista de empresas associadas ao usuario </para>
        /// <para> 3. Se o usuario nao contiver ultimaEmpresa e ListaEmpresa > 0, associa o primeiro item da ListaEmpresa como ultima empresa do usuario</para>
        /// <para> 4. Se o usuario.ultimaEmpresa != null, doAtualizarPermissoesUsuario(...)
        /// </summary>
        /// <returns>Usuario</returns>
        public Usuario doAutenticarUsuario(String telOrEmail, String senha)
        {
            //1.
            Usuario r = boUsuario.ObterListaObjeto(telOrEmail, senha);

            //2.
            List<UsuarioPerfil> ListaUsuarioPerfil = boUsuarioPerfil.ObterListaUsuarioPerfil(r);

            List<Perfil> Listaperfil = (from c in ListaUsuarioPerfil
                                                        select c.perfil).ToList();

            r.ListaEmpresa = new List<Empresa>(from c in Listaperfil
                                               select c.empresa).Distinct().ToList();

            //3.
            if (r.ultimaEmpresa == null)
            {
                if (r.ListaEmpresa.Count > 0)
                {
                    r.ultimaEmpresa = r.ListaEmpresa[0];
                }
            }

            //4.
            if (r.ultimaEmpresa != null)
            {
                doAtualizarPermissoesUsuario(r.ultimaEmpresa, r);
            }

            return r;
        }

        public void doAtualizarPermissoesUsuario(Empresa empresa, Usuario usuario)
        {
            //1. Recuperar lista de UsuarioPerfil uf where uf.usuario && uf.perfil.empresa
            List<UsuarioPerfil> listaUsuarioPerfil = boUsuarioPerfil.ObterListaObjeto(empresa, usuario);

            //2. Recuperar lista de PerfilFuncionalidade pf where pf.perfil in(listaPerfil)  [ lambda na listaUsuarioPerfil ]
            List<Perfil> listaPerfil = (from x in listaUsuarioPerfil
                                        select x.perfil).ToList();

            List<PerfilFuncionalidade> listaPerfilFuncionalidade = boPerfilFuncionalidade.ObterListaObjeto(listaPerfil);

            //3. Atualizar usuarioLogado.listaFuncionalidade [ lambda no listaPerfilFuncionalidade ]
            usuario.listaNomeFuncionalidade.Clear();
            usuario.listaNomeFuncionalidade.AddRange((from x in listaPerfilFuncionalidade
                                                      select x.funcionalidade.nome)
                                                             .ToList());
        }

        public List<Usuario> ObterListaUsuariodaEmpresa(Empresa empresa)
        {
            //1. Recuperar lista de Perfil que pertecem a empresaLogada 
            List<Perfil> listaPerfil = boPerfil.ObterListaPerfilporEmpresa(empresa);

            //2. Recuperar de lista de UsuarioPerfil
            List<UsuarioPerfil> listaUsuarioPerfil = boUsuarioPerfil.ObterListaObjeto(empresa);

            //3. Recuperar lista de Usuario que pertencem a empresa logada
            List<Usuario> listaUsuario = (from x in listaUsuarioPerfil
                                          where listaPerfil.Contains(x.perfil)
                                          select x.usuario).ToList();

            return listaUsuario;

        }
    }
}

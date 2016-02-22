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
        /// <para> 1. Verifica credenciais do usuário (telefone ou email + senha) </para>
        /// <para>2. Recupera a lista de Perfil a partir do Usuario + Empresa </para>
        /// <para>3. A partir da lista de perfil, adiciona ao Usuario a lista de Funcionalidade que o mesmo tem acesso </para>
        /// </summary>
        /// <returns>Usuario</returns>
        public Usuario doAutenticarUsuario(String telOrEmail,String senha)
        {
            Usuario r = boUsuario.ObterListaObjeto(telOrEmail, senha);

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
            List<UsuarioPerfil> listaUsuarioPerfil = boUsuarioPerfil.ObterListaObjeto();

            //3. Recuperar lista de Usuario que pertencem a empresa logada
            List<Usuario> listaUsuario= (from x in listaUsuarioPerfil
                                         where listaPerfil.Contains(x.perfil)
                                         select x.usuario).ToList();

            return listaUsuario;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.ce;
using System.Data.Entity;

namespace wpf_wakusese.src.main.model.bo
{
    public class BO_UsuarioPerfil : GenericoBO<UsuarioPerfil>
    {
        public UsuarioPerfil ObterUsuarioPerfil(string telefone, string senha)
        {
            UsuarioPerfil r = _DbSet
                                    .Include(o => o.perfil)
                                    .Include(o => o.usuario)
                                    .Where(o => o.usuario.telefone == telefone && o.usuario.senha == senha)
                                    .FirstOrDefault();
            if (r == null)
            {
                throw new ArgumentException("Não foi encontrado nenhum usuário com esse login e senha!");
            }

            return r;
        }

        public List<UsuarioPerfil> ObterListaObjeto(Empresa empresa, Usuario usuarioLogado)
        {
            List<UsuarioPerfil> r = _DbSet
                         .Include(o => o.perfil)
                         .Where(o => o.usuario.id == usuarioLogado.id && o.perfil.empresa.id == empresa.id)
                         .ToList();

            return r;
        }

        public ObservableCollection<UsuarioPerfil> ObterListaObjetoUsuario(Usuario usuFocado)
        {
            if (usuFocado != null)
            {
                List<UsuarioPerfil> r = _DbSet
                         .Include(o => o.perfil)
                    // .Include(o => o.perfil.empresa)
                         .Where(o => o.usuario.id == usuFocado.id)
                         .ToList();

                ObservableCollection<UsuarioPerfil> listObv = new ObservableCollection<UsuarioPerfil>(r);

                return listObv;
            }
            else
            {
                return null;
            }



        }

        public ObservableCollection<UsuarioPerfil> ObterListaUsuarioPerfilCliente()
        {
            String nomePerfil = "Cliente";
            List<UsuarioPerfil> listaUserPer = _DbSet

                                                .Where(o => o.perfil.nome == nomePerfil)
                                                .ToList();

            ObservableCollection<UsuarioPerfil> listObv = new ObservableCollection<UsuarioPerfil>(listaUserPer);
            return listObv;


        }

        public UsuarioPerfil ObterUsuarioPerfilPorUsuarioEPerfil(Usuario usuarioLogado, Perfil prf)
        {
            UsuarioPerfil usu = _DbSet
                                      .Where(o => o.usuario.id == usuarioLogado.id && o.perfil.id == prf.id)
                                      .FirstOrDefault();
            if (usu == null)
            {
                throw new ArgumentException("Não foi encontrado usuário com este telefone e senha!");
            }


            return usu;
        }
    }
}

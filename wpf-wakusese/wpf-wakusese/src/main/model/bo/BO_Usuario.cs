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
    public class BO_Usuario : GenericoBO<Usuario>
    {
        //public BO_Usuario()
        //    : base(EFDBContext.Instance)
        //{
        //    this._DbContext.Configuration.ProxyCreationEnabled = false;
        //}

        /// <summary>
        /// Este método é resposável por resetar a senha de um usuario
        /// <para> 1. Recupera um Usuario atraves do email </para>
        /// <para> 2. Reseta senha do usuario + marca o usuario como senha resetada</para>
        /// <para> 3. Envia um email para usuario com nova senha</para>
        /// </summary>
        /// <returns>Usuario</returns>
        public Usuario doResetarSenha(String email)
        {
            throw new NotImplementedException();
        }


        public override ObservableCollection<Usuario> ObterListaObjeto()
        {

            List<Usuario> lista = _DbSet
                                       .Include(o => o.endereco)
                                       .OrderBy(o => o.id)
                                       .ToList();

            ObservableCollection<Usuario> listObv = new ObservableCollection<Usuario>(lista);

            return listObv;
        }

        public Usuario ObterListaObjeto(string telefoneOrEmail, string senha)
        {
            Usuario r = _DbSet

                               .Where(o => o.telefone.Contains(telefoneOrEmail) || o.senha.Contains(senha))
                //.Where(o => o.telefone == telefoneOrEmail && o.senha == senha)
                               .FirstOrDefault();
            if (r == null)
            {
                throw new ArgumentException("Não foi encontrado usuário com este telefone e senha!");
            }
            return r;
        }

        public Usuario ObterListaObjeto(string telefone, string senha, string perfil)
        {
            Usuario r = _DbSet

                               .Where(o => o.telefone == telefone && o.senha == senha)
                               .FirstOrDefault();
            if (r == null)
            {
                throw new ArgumentException("Não foi encontrado usuário com este telefone e senha!");
            }
            return r;
        }

        public ObservableCollection<Usuario> ObserListaObjetoPorNumeroTelefone(string p)
        {
            List<Usuario> lista = _DbSet

                               .Include(o => o.endereco)
                               .Where(o => o.telefone.Contains(p))
                               .ToList();

            ObservableCollection<Usuario> listObv = new ObservableCollection<Usuario>(lista);
            return listObv;
        }

        public ObservableCollection<Usuario> ObserListaObjetoPorEmail(string p)
        {
            List<Usuario> lista = _DbSet

                               .Include(o => o.endereco)
                               .Where(o => o.email.Contains(p))
                               .ToList();

            ObservableCollection<Usuario> listObv = new ObservableCollection<Usuario>(lista);
            return listObv;
        }

        public virtual Usuario ObterUsuarioPorId(int id)
        {
            Usuario usuario = _DbSet
                                   .Include(o => o.endereco)
                                   .Where(o => o.id == id)
                                   .FirstOrDefault();
            return usuario;

        }

        public Usuario ObserListaObjetoPorNumeroTelefoneENome(string telefone, string nomeCliente)
        {
            Usuario usuario = _DbSet
                                   .Include(o => o.endereco)
                                   .Where(o => o.telefone == telefone && o.nome == nomeCliente)
                                   .FirstOrDefault();
            return usuario;
        }



        public ObservableCollection<Usuario> ObserListaObjetoPorNome(string p)
        {
            List<Usuario> lista = _DbSet

                              .Include(o => o.endereco)
                              .Where(o => o.nome.Contains(p))
                              .ToList();

            ObservableCollection<Usuario> listObv = new ObservableCollection<Usuario>(lista);
            return listObv;
        }

    }
}

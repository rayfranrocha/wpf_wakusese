using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace wpf_wakusese.src.main._utils
{
    public class BoPadrao<T> where T : EntityBase
    {
        protected DaoPadrao<T> dao;

        public BoPadrao() : base() {
            dao = new DaoPadrao<T>();
        }

        #region Implementacao dos Métodos do IDAOPadrao

        public void SaveChanges()
        {
            dao.SaveChanges();
        }

        public void AttachTo(T obj)
        {
            dao.AttachTo(obj);
        }

        public void Inserir(T obj)
        {
            dao.Inserir(obj);
        }

        public void Alterar(T obj)
        {
            dao.Alterar(obj);
        }

        public void Excluir(T obj)
        {
            dao.Excluir(obj);
        }

        public void ExcluirPorId(int id)
        {
            dao.ExcluirPorId(id);
        }

        public T ObterObjetoPorId(int id)
        {
            return dao.ObterObjetoPorId(id);
        }

        public T ObterObjetoAtualizado(T obj)
        {
            return ObterObjetoAtualizado(obj);
        }

        public virtual IEnumerable<T> ObterListaObjeto()
        {
            return dao.ObterListaObjeto();
        }

        public IEnumerable<T> ObterListaByQuery(Expression<Func<T, bool>> query = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            return dao.ObterListaByQuery(query, orderBy, includeProperties);
        }

        public T ObterPrimeiro(Expression<Func<T, bool>> predicate)
        {
            return dao.ObterPrimeiro(predicate);
        }

        #endregion

       
    }
}

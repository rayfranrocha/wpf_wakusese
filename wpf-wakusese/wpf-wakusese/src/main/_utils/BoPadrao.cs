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

        protected EFDBContext _DbContext;
        protected DaoPadrao<T> dao;

        public BoPadrao()
            : base()
        {
            _DbContext = new EFDBContext();
            dao = new DaoPadrao<T>(_DbContext);
        }

        public BoPadrao(EFDBContext dbContext)
            : base()
        {
            _DbContext = dbContext;
            dao = new DaoPadrao<T>(_DbContext);
        }

        #region Implementacao dos Métodos do IDAOPadrao

        public void Commit()
        {
            dao.Commit();
        }

        public void AttachTo(T obj)
        {
            dao.AttachTo(obj);
        }

        public void InserirOuAlterar(T obj)
        {
            dao.InserirOuAlterar(obj);
        }

        public void InserirOuAlterar(List<T> objs)
        {
            dao.InserirOuAlterar(objs);
        }

        public void AlterarCamposEpecificos(T obj, string[] campos)
        {
            dao.AlterarCamposEpecificos(obj, campos);
        }

        public void Excluir(List<T> objs)
        {
            dao.Excluir(objs);
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

        public T ObterPrimeiro(int id)
        {
            return dao.ObterPrimeiro(id);
        }

        #endregion


    }
}

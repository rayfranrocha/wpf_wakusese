using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace wpf_wakusese.src.main._utils
{
    public class DaoPadrao<T> where T : EntityBase
    {
        //private static RepositorioPadrao<T> _RepositorioPadraoSingleton;
        protected DbSet<T> _DbSet;
        protected DbContext _DbContext;

        #region Construtores

        public DaoPadrao()
        { }

        public DaoPadrao(DbContext db)
        {
            _DbContext = db;
            _DbSet = _DbContext.Set<T>();
        }

        #endregion

        //#region Padrão Singleton
        //public static RepositorioPadrao<T> GetInstance()
        //{
        //    if (_RepositorioPadraoSingleton == null) {
        //        _RepositorioPadraoSingleton = new RepositorioPadrao<T>();
        //    }
        //    return _RepositorioPadraoSingleton;
        //}
        //#endregion

        #region IRepository<T> Members

        public void Inserir(T obj)
        {
            _DbSet.Add(obj);
        }

        public void Alterar(T obj)
        {
            T objAtual = _DbSet.Find(obj.id);
            objAtual = obj;
            _DbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Excluir(T obj)
        {
            if (_DbContext.Entry(obj).State == EntityState.Detached)
                _DbSet.Attach(obj);

            _DbSet.Remove(obj);
        }

        public void ExcluirPorId(int id)
        {
            T obj = _DbSet.Find(id);
            _DbSet.Remove(obj);
        }

        public T ObterObjetoPorId(int id)
        {
            return _DbSet.Find(id);
        }

        public T ObterObjetoAtualizado(T obj)
        {
            return _DbSet.Find(obj.id);
        }

        public virtual IEnumerable<T> ObterListaObjeto()
        {
            return _DbSet.OrderBy(o => o.id).ToList();
        }

        public IEnumerable<T> ObterListaByQuery(Expression<Func<T, bool>> query = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> queryResult = _DbSet;

            //If there is a query, execute it against the dbset
            if (query != null)
            {
                queryResult = queryResult.Where(query);
            }

            //get the include requests for the navigation properties and add them to the query result
            foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                queryResult = queryResult.Include(property);
            }

            //if a sort request is made, order the query accordingly.
            if (orderBy != null)
            {
                return orderBy(queryResult).ToList();
            }
            //if not, return the results as is
            else
            {
                return queryResult.ToList();
            }
        }

        public T ObterPrimeiro(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.First(predicate);
        }

        #endregion

    }
}

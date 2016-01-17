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
        private DbSet<T> _DbSet;
        private EFDBContext _DbContext;

        #region Construtores

        public DaoPadrao(EFDBContext dbContext)
        {
            _DbContext = dbContext;
            DefinirDBSet();
        }

        private void DefinirDBSet()
        {
            //recebe um DbSet
            object DbSetObject = _DbContext.GetDBSet(typeof(T));

            //convert num DbSet<T>
            _DbSet = (DbSet<T>)DbSetObject;
        }


        #endregion

        #region Metodos DML Padrão

        public void SaveChanges()
        {
            _DbContext.SaveChanges();
        }

        public void AttachTo(T obj)
        {
            _DbSet.Attach(obj);
        }

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

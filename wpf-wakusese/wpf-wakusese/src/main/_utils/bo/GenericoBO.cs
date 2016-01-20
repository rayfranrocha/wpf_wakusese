﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace wpf_wakusese.src.main._utils.bo
{
    public class GenericoBO<T> where T : EntityBase
    {
        protected EFDBContext _DbContext;
        protected DbSet<T> _DbSet;

        public GenericoBO()
            : base()
        {
            _DbContext = new EFDBContext();
            _DbSet = (DbSet<T>)_DbContext.GetDBSet(typeof(T));
        }

        public GenericoBO(EFDBContext dbContext)
            : base()
        {
            _DbContext = dbContext;
            _DbContext.GetDBSet(typeof(T));
        }

        #region Implementacao dos Métodos do IDAOPadrao

        public void SaveChanges()
        {
            _DbContext.SaveChanges();
        }

        public void Attach(T obj)
        {
            _DbSet.Attach(obj);
        }

        public void InserirOuAlterar(List<T> objs)
        {

            foreach (var item in objs)
            {
                InserirOuAlterar(item);
            }
        }

        public virtual void InserirOuAlterar(T obj)
        {
            //Toda vez que utilizar este comando, forçamos a VALIDAÇÃO AUTOMATICA (ex. Campos REQUIRED, Tamanho de campos etc).
            _DbContext.Configuration.ValidateOnSaveEnabled = true;

            //verifica se utilizará Inserir ou Alterar
            if (obj.id == 0)
            {
                Inserir(obj);
            }
            else
            {
                Alterar(obj);
            }
        }

        private void Inserir(T obj)
        {
            _DbSet.Add(obj);
        }

        private void Alterar(T obj)
        {
            if (_DbContext.Entry(obj).State == EntityState.Detached)
                throw new Exception("Não foi possível realizar UPDATE, pois o objeto com id=" + obj.id + " está com status DETACHED. Verifique!");

            _DbContext.Entry(obj).State = EntityState.Modified;
        }

        public void AlterarCamposEpecificos(T obj, params string[] campos)
        {

            Attach(obj);

            foreach (var campo in campos)
            {
                _DbContext.Entry(obj).Property(campo).IsModified = true;
            }

            //Para evitar erros de validação de Propriedade REQUIRED, desabilitamos a validação ao salvar
            _DbContext.Configuration.ValidateOnSaveEnabled = false;

        }

        public void Excluir(List<T> objs)
        {
            foreach (var item in objs)
            {
                Excluir(item);
            }
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
            if (obj.id == 0) { throw new Exception("Você tentou atualizar um objeto com ID nulo."); }

            return _DbSet.Find(obj.id);
        }

        public virtual IEnumerable<T> ObterListaObjeto()
        {
            return _DbSet.OrderBy(o => o.id).ToList();
        }

        public IEnumerable<T> ObterListaByQuery(Expression<Func<T, bool>> where = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> queryResult = _DbSet;

            //If there is a query, execute it against the dbset
            if (where != null)
            {
                queryResult = queryResult.Where(where);
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

        public IEnumerable<T> ObterListaBySQLNativo(String sql, object[] parametros)
        {
            return _DbSet.SqlQuery(sql, parametros);
        }

        public T ObterPrimeiro(Expression<Func<T, bool>> where)
        {
            return _DbSet.First(where);
        }

        public T ObterPrimeiro(int id)
        {
            return _DbSet.First(o => o.id == id);
        }

        #endregion


    }
}
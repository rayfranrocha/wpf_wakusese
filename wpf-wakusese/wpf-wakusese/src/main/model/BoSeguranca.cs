using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.seguranca.dao;

namespace wpf_wakusese.src.main.model
{
    public class BoSeguranca : IDisposable
    {
        private DbContext _DbContext = null;
        private bool _Disposed = false;

        public BoSeguranca()
        {
            _DbContext = new EFDBContext();
        }

        #region Public Methods
        /// <summary>
        /// Used to save the changes to the underlying data store.
        /// </summary>
        public virtual void Commit()
        {
            _DbContext.SaveChanges();
        }
        #endregion

        #region Dispose Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!this._Disposed)
            {
                if (disposing)
                    _DbContext.Dispose();
            }
            this._Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Obter Repositorios (Padrao Singleton)

        public DaoFuncionalidade daoFuncionalidade
        {
            get
            {
                return new DaoFuncionalidade(this._DbContext);
            }
        }

        #endregion

    }

}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;

namespace wpf_wakusese.src.main.model.seguranca.dao
{
    public class DaoFuncionalidade : DaoPadrao<Funcionalidade>
    {
        public DaoFuncionalidade(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}

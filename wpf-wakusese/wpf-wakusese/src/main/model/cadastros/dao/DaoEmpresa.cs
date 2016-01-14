using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.model;
using wpf_wakusese.src.main._utils;

namespace wpf_wakusese.src.main.model.cadastros.dao
{
    public class DaoEmpresa : DaoPadrao<Empresa>
    {
        public DaoEmpresa(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}

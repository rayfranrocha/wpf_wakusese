using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main._utils.bo;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.model.bo
{
    public class EmpresaBO : GenericoBO<Empresa>
    {
        public EmpresaBO(EFDBContext dbContext)
            : base(dbContext)
        {
        }
    }
}

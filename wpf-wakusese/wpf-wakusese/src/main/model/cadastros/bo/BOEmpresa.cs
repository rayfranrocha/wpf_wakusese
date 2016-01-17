using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.cadastros.ce;

namespace wpf_wakusese.src.main.model.cadastros.bo
{
    public class BOEmpresa : BoPadrao<Empresa>
    {
        public BOEmpresa()
            : base()
        {
        }
        public BOEmpresa(EFDBContext dbContext)
            : base(dbContext)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.model.bo
{
    public class BO_Pedido : GenericoBO<Pedido>
    {
        public BO_Pedido(EFDBContext dbContext)
            : base(dbContext)
        {
        }
    }
}

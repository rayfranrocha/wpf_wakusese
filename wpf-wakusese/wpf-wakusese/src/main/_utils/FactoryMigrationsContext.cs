using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_wakusese.src.main._utils
{
    //SE UTILIZAR ESTA OPCAO SEU O CONSTRUTOR PUBLICO DO EFDBCONTEXT, O COMANDO Add-Migration dá o seguinte erro:
            //The operation cannot be completed because the DbContext has been disposed.
    public class FactoryMigrationsContext //: IDbContextFactory<EFDBContext>
    {
        public EFDBContext Create()
        {
            return EFDBContext.Instance;
        }
    }
}

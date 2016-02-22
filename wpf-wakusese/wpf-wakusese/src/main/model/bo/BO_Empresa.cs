using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.model.bo
{
    public class BO_Empresa : GenericoBO<Empresa>
    {
        public override List<Empresa> ObterListaObjeto()
        {

            List<Empresa> lista = _DbSet
                                       .Include(o => o.endereco)
                                       .OrderBy(o => o.id)
                                       .ToList();

            //ObservableCollection<Empresa> listObv = new ObservableCollection<Empresa>(lista);

            return lista;
        }

        public Empresa ObterEmpresaPorId(int p)
        {
            Empresa emp = _DbSet
                                        .Include(o => o.endereco)
                                        .Where(o => o.id == p)
                                        .FirstOrDefault();

            return emp;
        }
    }
}

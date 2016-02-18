using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.model.bo
{
    public class BO_Categoria : GenericoBO<Categoria>
    {
        public BO_Categoria(EFDBContext dbContext)
            : base(dbContext)
        {
        }

        //Este Comentário foi feito pelo Alisson

        public ObservableCollection<Categoria> ObterListaCategoriadaEmpresa(Empresa empresa)
        {
            List<Categoria> lista = _DbSet
                //.Include(o => o.categoriaPai)
                                       .Where(o => o.empresa.id == empresa.id)
                                       .OrderBy(o => o.id)
                                       .ToList();

            ObservableCollection<Categoria> listObv = new ObservableCollection<Categoria>(lista);

            return listObv;
        }
    }
}

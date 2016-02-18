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
    public class BO_Pedido : GenericoBO<Pedido>
    {
        public BO_Pedido()
            : base()
        {
        }

        public override Pedido ObterObjetoAtualizado(Pedido obj)
        {
            Pedido r = _DbSet
                                .Include(o => o.cliente)
                                .Where(o => o.id == obj.id)
                                .FirstOrDefault();

            return r;
        }

        //VERIFICAR SE ESTE METODO É NECESSÁRIO
        public virtual int ObterUltimoIdPedido()
        {

            List<Pedido> lista = _DbSet

                                       .OrderBy(o => o.id)
                                       .ToList();

            ObservableCollection<Pedido> listObv = new ObservableCollection<Pedido>(lista);

            if (lista.Count != 0)
            {
                return lista.Max(c => c.id);
            }
            else
            {
                return 0;
            }



        }

        //VERIFICAR SE ESTE METODO É NECESSÁRIO
        public virtual Pedido ObterUltimoPedido()
        {
            int x;
            List<Pedido> lista = _DbSet
                                       .Include(o => o.cliente)
                                       .OrderBy(o => o.id)
                                       .ToList();

            ObservableCollection<Pedido> listObv = new ObservableCollection<Pedido>(lista);

            if (lista.Count != 0)
            {
                x = lista.Max(c => c.id);

                Pedido pedido = _DbSet

                                       .Where(o => o.id == x)
                                       .FirstOrDefault();
                return pedido;
            }
            else
            {
                return null;
            }





        }

        //VERIFICAR SE ESTE METODO É NECESSÁRIO
        public ObservableCollection<Pedido> ObterListaPedidosNaoPagos()
        {
            List<Pedido> r = _DbSet
                                           .Include(o => o.cliente)
                                           .Where(o => o.isPago == false)
                                           .ToList();

            ObservableCollection<Pedido> lista = new ObservableCollection<Pedido>(r);

            return lista;
        }

    }
}

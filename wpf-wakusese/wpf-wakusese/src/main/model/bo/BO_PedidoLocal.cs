using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.ce;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace wpf_wakusese.src.main.model.bo
{
    public class BO_PedidoLocal : GenericoBO<PedidoLocal>
    {
        public BO_PedidoLocal(EFDBContext dbContext)
            : base(dbContext)
        {
        }

        public System.Collections.ObjectModel.ObservableCollection<PedidoLocal> ObterListaPedidosLocalEmProcesso()
        {
            List<PedidoLocal> list = _DbSet
                                        .Include(o => o.pedido)
                                        .Include(o => o.pedido.cliente)
                                        .Include(o => o.empresa)
                                        .Where(o => o.checkout < o.checkin)
                                        .ToList();



            ObservableCollection<PedidoLocal> listObs = new ObservableCollection<PedidoLocal>(list);
            return listObs;
        }

        public PedidoLocal ObterObjetoPorId(int id)
        {
            PedidoLocal obj = _DbSet
                                        .Include(o => o.pedido)
                //.Include(o => o.pedido.cliente)
                //.Include(o => o.empresa)
                                        .Where(o => o.id == id)
                                        .FirstOrDefault();




            return obj;
        }

        public int ObterUltimoIdPedidoLocal()
        {
            List<PedidoLocal> lista = _DbSet

                                      .OrderBy(o => o.id)
                                      .ToList();

            ObservableCollection<PedidoLocal> listObv = new ObservableCollection<PedidoLocal>(lista);

            if (lista.Count != 0)
            {
                return lista.Max(c => c.id);
            }
            else
            {
                return 0;
            }
        }

        public PedidoLocal ObterPedidoLocalporIdPedido(int p)
        {
            PedidoLocal obj = _DbSet
                                        .Include(o => o.pedido)
                //.Include(o => o.pedido.cliente)
                //.Include(o => o.empresa)
                                        .Where(o => o.pedido.id == p)
                                        .FirstOrDefault();




            return obj;
        }
    }
}

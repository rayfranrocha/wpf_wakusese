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
    public class BO_PedidoDelivery : GenericoBO<PedidoDelivery>
    {
        public BO_PedidoDelivery(EFDBContext dbContext)
            : base(dbContext)
        {
        }
        //
        public System.Collections.ObjectModel.ObservableCollection<PedidoDelivery> ObterListaDeliveryEmProcesso(Empresa empresa)
        {
            List<PedidoDelivery> list = _DbSet
                                        .Include(o => o.pedido)
                                        .Include(o => o.pedido.cliente)
                                        .Include(o => o.pedido.cliente.endereco)
                                        .Include(o => o.empresa)
                                        .Where(o => o.horaEntrega < o.horaPedido && o.empresa.id == empresa.id)
                                        .ToList();



            ObservableCollection<PedidoDelivery> listObs = new ObservableCollection<PedidoDelivery>(list);
            return listObs;
        }

        public int ObterUltimoIdPedidoDelivery()
        {
            List<PedidoDelivery> lista = _DbSet

                                      .OrderBy(o => o.id)
                                      .ToList();

            ObservableCollection<PedidoDelivery> listObv = new ObservableCollection<PedidoDelivery>(lista);

            if (lista.Count != 0)
            {
                return lista.Max(c => c.id);
            }
            else
            {
                return 0;
            }
        }

        public PedidoDelivery ObterObjetoPorId(int id)
        {
            PedidoDelivery obj = _DbSet
                                        .Include(o => o.pedido)
                //.Include(o => o.pedido.cliente)
                //.Include(o => o.empresa)
                                        .Where(o => o.id == id)
                                        .FirstOrDefault();

            return obj;
        }
    }
}

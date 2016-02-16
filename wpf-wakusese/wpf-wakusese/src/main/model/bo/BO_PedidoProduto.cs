using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.ce;
using System.Data.Entity;

namespace wpf_wakusese.src.main.model.bo
{
    public class BO_PedidoProduto : GenericoBO<PedidoProduto>
    {
        public BO_PedidoProduto(EFDBContext dbContext)
            : base(dbContext)
        {
        }

        public virtual ObservableCollection<PedidoProduto> ObterListaObjeto()
        {
            List<PedidoProduto> lista = _DbSet
                                   .Include(o => o.produto)
                                   .Include(o => o.pedido)
                                   .ToList();

            ObservableCollection<PedidoProduto> listObv = new ObservableCollection<PedidoProduto>(lista);

            return listObv;
        }

        public ObservableCollection<PedidoProduto> ObterListaItemsdoPedido(Pedido pedido)
        {
            List<PedidoProduto> lista = _DbSet
                                   .Include(o => o.produto)
                                   .Include(o => o.pedido)
                                   .Where(o => o.pedido.id == pedido.id)
                                   .ToList();

            ObservableCollection<PedidoProduto> listObv = new ObservableCollection<PedidoProduto>(lista);

            return listObv;
        }

        public decimal ObterSubTotaldoPedido(int p)
        {
            List<PedidoProduto> lista = _DbSet
                                   .Include(o => o.produto)
                                   .Include(o => o.pedido)
                                   .Where(o => o.pedido.id == p)
                                   .ToList();

            return lista.Sum(s => s.total);
            //throw new NotImplementedException();
        }

        public ObservableCollection<PedidoProduto> ObterListaPedidosNaoPago()
        {
            List<PedidoProduto> r = _DbSet
                                           .Include(o => o.pedido)
                                           .Include(o => o.produto)
                                           .Where(o => o.pedido.isPago == false)

                                           .ToList();

            ObservableCollection<PedidoProduto> lista = new ObservableCollection<PedidoProduto>(r);

            return lista;
        }



        public List<PedidoProduto> ObterListaPedidosNaoPagoIdPedido(int p)
        {

            List<PedidoProduto> r = _DbSet
                                           .Include(o => o.pedido)
                                           .Include(o => o.produto)
                                           .Where(o => o.pedido.id == p)
                                           .ToList();

            // ObservableCollection<PedidoProduto> lista = new ObservableCollection<PedidoProduto>(r);

            return r;
        }

        public PedidoProduto ObterPedidoProduto(int produto, int pedidoId)
        {
            PedidoProduto r = _DbSet

                               .Include(o => o.pedido)
                               .Include(o => o.produto)
                               .Where(o => o.produto.id == produto && o.pedido.id == pedidoId)
                               .FirstOrDefault();
            //if (r == null)
            //{
            //    throw new ArgumentException("Não foi encontrado usuário com este telefone e senha!");
            //}
            return r;
        }
    }
}

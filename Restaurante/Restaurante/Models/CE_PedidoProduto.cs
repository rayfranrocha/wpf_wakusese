using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_PedidoProduto
    {
        [Key]
        public int pedProdId { get; set; }
        public bool pedProdisItensCarr { get; set; }
        public decimal pedProdQtde { get; set; }
        public decimal pedProdPrecPromo { get; set; }
        public decimal pedProdPrecPadrao { get; set; }
        public decimal pedProdGetTotal{ get; set; }
        //{
        //    get { return this.pedProdQtde * this.pedProdPrecPadrao; }
        //    set {pedProdGetTotal = this.pedProdQtde * this.pedProdPrecPadrao; }    
        //}

        [ForeignKey("Produto")]
        public int pedProdProdutoId { get; set; }
        public CE_Produto Produto { get; set; }

        [ForeignKey("Pedido")]
        public int pedProdPedidoId { get; set; }
        public CE_Pedido Pedido { get; set; }
    }
}
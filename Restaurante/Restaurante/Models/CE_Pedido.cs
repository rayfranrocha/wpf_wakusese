using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_Pedido
    {
        [Key]
        public int pedidoId { get; set; }
        public int pedidoFormPgto { get; set; }
        public bool pedidoIsPago { get; set; }
        public bool pedidoIsPontoFidelidade { get; set; }
        public bool pedidoIsFidelidConsumido { get; set; }

        [ForeignKey("Usuario")]
        public int pedidoUsuarioId { get; set; }
        public CE_Usuario Usuario { get; set; }

        public ICollection<CE_PedidoProduto> PedidoProduto { get; set; }

        public ICollection<CE_PedidoLocal> PedidoLocal { get; set; }

        public ICollection<CE_PedidoDelivery> PedidoDelivery { get; set; }
    }
}
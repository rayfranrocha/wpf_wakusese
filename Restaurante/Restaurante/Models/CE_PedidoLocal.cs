using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_PedidoLocal
    {
        [Key]
        public int pedLocalId { get; set; }
        public string pedLocalNome { get; set; }
        public DateTime pedLocalCheckin { get; set; }
        public DateTime pedLocalCheckout { get; set; }

        [ForeignKey("Empresa")]
        public int PedidoLocalEmpresaId { get; set; }
        public CE_Empresa Empresa { get; set; }

        [ForeignKey("Pedido")]
        public int PedidoLocalPedidoId { get; set; }
        public CE_Pedido Pedido { get; set; }
    }
}
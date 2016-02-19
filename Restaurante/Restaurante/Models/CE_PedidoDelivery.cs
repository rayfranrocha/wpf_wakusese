using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_PedidoDelivery
    {
        [Key]
        public int pedDeliId { get; set; }
        public DateTime pedDeliHoraPedido { get; set; }
        public DateTime pedDeliHoraLiberacao { get; set; }
        public DateTime pedDeliHoraEntrega { get; set; }

        [ForeignKey("Empresa")]
        public int pedDeliEmpresaId { get; set; }
        public CE_Empresa Empresa { get; set; }

        [ForeignKey("Pedido")]
        public int pedDeliPedidoId { get; set; }
        public CE_Pedido Pedido { get; set; }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{   
    public class CE_Empresa
    {
        [Key]
        public int empresaId { get; set; }
        public int empresaCNPJ { get; set; }
        public string empresaNome { get; set; }
        public string empresaLocal { get; set; }
        public decimal empresaPercTxServico { get; set; }
        public decimal empresaValorTxEntrega { get; set; }

        public ICollection<CE_ValePresente> ValePresente { get; set; }

        public ICollection<CE_ValePresenteAvulso> ValePresenteAvulso { get; set; }

        public ICollection<CE_Caracteristica> Caracteristica { get; set; }

        public ICollection<CE_Categoria> Categoria { get; set; }

        public ICollection<CE_PedidoLocal> PedidoLocal { get; set; }

        public ICollection<CE_PedidoDelivery> PedidoDelivery { get; set; }

        public ICollection<CE_Perfil> Perfil { get; set; }

        [ForeignKey("Endereco")]
        public int empresaEnderecoId { get; set; }
        public CE_Endereco Endereco { get; set; }

    }
}
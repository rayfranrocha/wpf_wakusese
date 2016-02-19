using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_Produto
    {
        [Key]
        public int prodId { get; set; }
        public string prodNome { get; set; }
        public string prodDesc { get; set; }
        public byte[] prodImg1 { get; set; }
        public byte[] prodImg2 { get; set; }
        public byte[] prodImg3 { get; set; }
        public decimal prodPreco { get; set; }
        public int prodAvaliacaoMedia { get; set; }

        public ICollection<CE_ProdCaractValor> ProdCaractValor { get; set; }

        public ICollection<CE_PedidoProduto> PedidoProduto { get; set; }

        public ICollection<CE_Promocao> Promocao { get; set; }

    }
}
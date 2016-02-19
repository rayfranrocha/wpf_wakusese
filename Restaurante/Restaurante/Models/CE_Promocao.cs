using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_Promocao
    {
        [Key]
        public int promoId { get; set; }
        public DateTime promoInicio { get; set; }
        public DateTime promoFim { get; set; }
        public decimal promoPreco { get; set; }


        [ForeignKey("Produto")]
        public int promocaoProdutoId { get; set; }
        public CE_Produto Produto { get; set; }

       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_ProdCaractValor
    {
        [Key]
        public int prodCaractValorId { get; set; }

        [ForeignKey("Produto")]
        public int ProdCaractValorProdtId { get; set; }
        public CE_Produto Produto { get; set; }

        [ForeignKey("CaracteristicaValor")]
        public int ProdCaractValorCaracteristicaValorId { get; set; }
        public CE_CaracteristicaValor CaracteristicaValor { get; set; }
    }
}
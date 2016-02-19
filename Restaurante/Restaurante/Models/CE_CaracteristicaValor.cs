using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_CaracteristicaValor
    {
        [Key][Required]
        public int caractValId { get; set; }
        [Required]
        public string caractValValor { get; set; }

        [ForeignKey("Caracteristica")]
        public int caractValorCaractId { get; set; }
        public CE_Caracteristica Caracteristica { get; set; }


        public ICollection<CE_ProdCaractValor> ProdCaractValor { get; set; }
    }
}
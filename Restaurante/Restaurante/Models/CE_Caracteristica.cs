using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_Caracteristica
    {
        [Key][Required]
        public int caractId { get; set; }
        [Required]
        public string caractNome { get; set; }

        [ForeignKey("Empresa")]
        public int caractEmpresaId { get; set; }
        public CE_Empresa Empresa { get; set; }

        public ICollection<CE_CaracteristicaValor> CaracteristicaValor { get; set; }

        
    }
}
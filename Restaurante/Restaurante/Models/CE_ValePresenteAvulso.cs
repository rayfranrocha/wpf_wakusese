using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_ValePresenteAvulso
    {
        [Key]
        public int valePresId { get; set; }
        public string valePresNome { get; set; }
        public string valePresEmail { get; set; }
        public int valePresValor { get; set; }

        [ForeignKey("Empresa")]
        public int valePresenteAvulsoEmpresaId { get; set; }
        public CE_Empresa Empresa { get; set; }

    }
}
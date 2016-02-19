using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_ValePresente
    {
        [Key]
        public int valePresenteId { get; set; }
        public double valePresentevalor { get; set; }
        public IEnumerable<CE_Empresa> valePresenteEmpIdList { get; set; }

        [ForeignKey("Empresa")]
        public int valePresenteEmpresaId { get; set; }
        public CE_Empresa Empresa { get; set; }
    }
}
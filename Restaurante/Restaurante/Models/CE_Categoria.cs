using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_Categoria
    {
        [Key]
        [Required]
        public int categId { get; set; }
        public byte categImg { get; set; }
        public string categNome { get; set; }
        public CE_Categoria categCategoriaPai { get; set; }

        [ForeignKey("Empresa")]
        public int categEmpresaId { get; set; }
        public CE_Empresa Empresa { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_Endereco
    {
        [Key][Required]
        public int endeId { get; set; }
        public int endeLati { get; set; }
        public int endeLongi { get; set; }
        public string endeLograd { get; set; }
        public string endePontoRefer { get; set; }
        [Required]
        [Range(typeof(decimal), "0,0", "999999999,0")]
        [DisplayName("CEP")]
        public string endeCEP { get; set; }

        public ICollection<CE_Empresa> Empresa { get; set; }

        public ICollection<CE_Usuario> Usuario { get; set; }
    }
}
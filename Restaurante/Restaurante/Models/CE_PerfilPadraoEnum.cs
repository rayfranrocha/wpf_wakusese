using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_PerfilPadraoEnum
    {
        [Key]
        public int perfilPadraoEnumId { get; set; }
        public string perfilPadraoEnumTipo { get; set; }

        public ICollection<CE_Perfil> Perfil { get; set; }
    }
}
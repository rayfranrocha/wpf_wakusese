using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_Perfil
    {
        [Key]
        public int perfilId { get; set; }

        public ICollection<CE_UsuarioPerfil> UsuarioPerfil { get; set; }

        [ForeignKey("Empresa")]
        public int perfilEmpresaId { get; set; }
        public CE_Empresa Empresa { get; set; }

        [ForeignKey("PerfilPadraoEnum")]
        public int perfilPerfilPadraoEnumId { get; set; }
        public CE_PerfilPadraoEnum PerfilPadraoEnum { get; set; }
    }
}
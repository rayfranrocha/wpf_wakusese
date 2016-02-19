using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_UsuarioPerfil
    {
        [Key]
        public int usuarioPerfilId { get; set; }

        [ForeignKey("Usuario")]
        public int usuarioPerfilUsuarioId { get; set; }
        public CE_Usuario Usuario { get; set; }

        [ForeignKey("Perfil")]
        public int usuarioPerfilPerfilId { get; set; }
        public CE_Perfil Perfil { get; set; }
    }
}
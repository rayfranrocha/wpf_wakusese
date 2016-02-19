using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante
{
    public class CE_PerfilFuncionalidade
    {
        [Key]
        public int perfilFuncioId { get; set; }

        [ForeignKey("Funcionalidade")]
        public int perfilFuncioFuncioId { get; set; }
        public CE_Funcionalidade Funcionalidade { get; set; }


        [ForeignKey("Perfil")]
        public int perfilFuncioPerfilId { get; set; }
        public CE_Perfil Perfil { get; set; }
    }
}
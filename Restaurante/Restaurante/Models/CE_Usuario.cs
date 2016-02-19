using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante
{
    public class CE_Usuario
    {
        [Key]
        public int usuId { get; set; }
        public string usuEmail { get; set; }
        public int usuTelef { get; set; }
        public string usuImeiTelef { get; set; }
        public string usuSenha { get; set; }
        public string usuNome { get; set; }
        public DateTime usuDataNasc { get; set; }
        public string usuFacebook { get; set; }
        public string usuInstagram { get; set; }
        public Boolean usuIsPermanLogado { get; set; }
        public string usuNivelAcesso { get; set; }

        public ICollection<CE_Pedido> Pedido { get; set; }

        public ICollection<CE_UsuarioPerfil> UsuarioPerfil { get; set; }

        [ForeignKey("Endereco")]
        public int usuarioEnderecoId { get; set; }
        public CE_Endereco Endereco { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wpf_wakusese.src.main._utils;

namespace wpf_wakusese.src.main.model.ce
{
    public class UsuarioPerfil : EntityBase
    {
        private Usuario _usuario;
        private Perfil _perfil;

        [Required]
        [Display(Name = "Usuario")]
        [Index("IX_UsuarioPerfil", Order = 1, IsUnique = true)]
        public Usuario usuario
        {
            get { return _usuario; }
            set { _usuario = value; RaisePropertyChanged("usuario"); }
        }

        [Required]
        [Display(Name = "Perfil")]
        [Index("IX_UsuarioPerfil", Order = 2, IsUnique = true)]
        public Perfil perfil
        {
            get { return _perfil; }
            set { _perfil = value; RaisePropertyChanged("perfil"); }
        }

    }
}

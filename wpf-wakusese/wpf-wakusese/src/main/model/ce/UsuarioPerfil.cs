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
        public Usuario usuario
        {
            get { return _usuario; }
            set { _usuario = value; RaisePropertyChanged("usuario"); }
        }

        [Required]
        [Display(Name = "Perfil")]
        public Perfil perfil
        {
            get { return _perfil; }
            set { _perfil = value; RaisePropertyChanged("perfil"); }
        }

    }
}

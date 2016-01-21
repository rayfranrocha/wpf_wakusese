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
    public class PerfilFuncionalidade : EntityBase
    {
        private Perfil _perfil;
        private Funcionalidade _funcionalidade;

        [Required]
        [Display(Name = "Perfil")]
        [Index("IX_PerfilFuncionalidade", Order=1, IsUnique = true)]
        public Perfil perfil
        {
            get { return _perfil; }
            set { _perfil = value; RaisePropertyChanged("perfil"); }
        }

        [Required]
        [Display(Name = "Funcionalidade")]
        [Index("IX_PerfilFuncionalidade", Order = 2, IsUnique = true)]
        public Funcionalidade funcionalidade 
        {
            get { return _funcionalidade; }

            set { _funcionalidade = value; RaisePropertyChanged("funcionalidade"); }
        }

       
    }
}

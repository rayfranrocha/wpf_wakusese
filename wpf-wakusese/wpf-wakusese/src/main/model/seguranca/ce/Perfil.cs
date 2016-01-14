using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wpf_wakusese.src.main._utils;

namespace wpf_wakusese.model
{
    public class Perfil : EntityBase
    {
        private Empresa _empresa;
        private String _nome;

        [Required]
        [Display(Name = "Empresa")]
        public Empresa empresa {
            get { return _empresa; }
            set { _empresa = value; RaisePropertyChanged("empresa"); }
        }

        [Display(Name = "Nome")]
        [Column("nome")]
        public String nome {
            get { return _nome; }
            set { _nome = value; RaisePropertyChanged("nome"); }
        }

        [NotMapped]
        public string perfilEmpresa
        {
            get { return this.nome + " | Empresa: "+ this.empresa.nome; }
        }
    }
}

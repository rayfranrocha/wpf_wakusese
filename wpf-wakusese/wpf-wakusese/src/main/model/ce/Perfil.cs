using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.enums;

namespace wpf_wakusese.src.main.model.ce
{
    public class Perfil : EntityBase
    {
        private Empresa _empresa;
        private String _nome;
        private PerfilPadraoEnum _perfilPadraoEnum;

        [Required]
        [Display(Name = "Empresa")]
        public Empresa empresa
        {
            get { return _empresa; }
            set { _empresa = value; RaisePropertyChanged("empresa"); }
        }

        [Display(Name = "Nome")]
        public String nome
        {
            get { return _nome; }
            set { _nome = value; RaisePropertyChanged("nome"); }
        }

        [Display(Name = "Perfil Padrão")]
        public PerfilPadraoEnum perfilPadraoEnum
        {
            get { return _perfilPadraoEnum; }
            set { _perfilPadraoEnum = value; RaisePropertyChanged("perfilPadraoEnum"); }
        }

        [NotMapped]
        public string perfilEmpresa
        {
            get { return this.nome + " | Empresa: " + this.empresa.nome; }
        }
    }
}

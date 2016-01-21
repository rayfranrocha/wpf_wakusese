using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.model.ce
{
    public class ValePresente : EntityBase
    {
        private Empresa _empresa { get; set; }
        private Decimal _valor { get; set; }
        private Usuario _beneficiado { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        public Empresa empresa 
        {
            get { return _empresa; }
            set { _empresa = value; RaisePropertyChanged("empresa"); }
        }

        [Display(Name = "Valor")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Valor deve ser maior que zero. Verifique!")]
        [DisplayFormat(ApplyFormatInEditMode = false,DataFormatString="{0:N2}",NullDisplayText="Sem valor.")]
        public Decimal valor 
        {
            get { return _valor; }
            set { _valor = value; RaisePropertyChanged("valor"); }
        }

        [Display(Name = "Beneficiado")]
        public Usuario beneficiado {
            get { return _beneficiado; }
            set { _beneficiado = value; RaisePropertyChanged("beneficiado"); }
        }
    }
}

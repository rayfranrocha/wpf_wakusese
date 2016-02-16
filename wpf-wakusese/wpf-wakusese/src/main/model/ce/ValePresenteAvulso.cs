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
    public class ValePresenteAvulso : EntityBase
    {
        private Empresa _empresa;
        private Decimal _valor;
        private String _codigoValePresente;
        private String _nome;
        private String _email;

        [Required]
        [Display(Name = "Empresa")]
        public Empresa empresa
        {
            get { return _empresa; }
            set { _empresa = value; RaisePropertyChanged("empresa"); }
        }

        [Display(Name = "Valor")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Valor deve ser maior que zero. Verifique!")]
        [DisplayFormat(DataFormatString = "{0:n2}", NullDisplayText = "Sem valor.", ApplyFormatInEditMode = false)]
        public Decimal valor
        {
            get { return _valor; }
            set { _valor = value; RaisePropertyChanged("valor"); }
        }

        [Display(Name = "Código Vale Presente")]
        public String codigoValePresente
        {
            get { return _codigoValePresente; }
            set { _codigoValePresente = value; RaisePropertyChanged("codigoValePresente"); }
        }

        [Display(Name = "Nome")]
        public String nome
        {
            get { return _nome; }
            set { _nome = value; RaisePropertyChanged("nome"); }
        }

        [Display(Name = "Email")]
        public String email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged("email"); }
        }

    }
}

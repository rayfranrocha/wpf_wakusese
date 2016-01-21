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
    public class Promocao : EntityBase
    {
        private DateTime _inicio;
        private DateTime _fim;
        private Decimal _preco;
        private Produto _produto;
        
        [Required]
        [Display(Name = "Produto")]
        public Produto produto 
        {
            get { return _produto; }
            set { _produto = value; RaisePropertyChanged("produto"); }
        }

        [Display(Name = "Início")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime inicio 
        {
            get { return _inicio; }
            set { _inicio = value; RaisePropertyChanged("inicio"); }
        }

        [Display(Name = "Fim")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fim 
        {
            get { return _fim; }
            set { _fim = value; RaisePropertyChanged("fim"); }
        }

        [Display(Name = "Preço")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Valor deve ser maior que zero. Verifique!")]
        [DisplayFormat(DataFormatString = "{0:n2}", NullDisplayText = "Sem valor.", ApplyFormatInEditMode = false)]
        public Decimal preco 
        {
            get { return _preco; }
            set { _preco = value; RaisePropertyChanged("preco"); }
        }
    }
}

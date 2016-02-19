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
    public class ProdutoCaractValor : EntityBase
    {
        private CaracteristicaValor _caracteristicaValor;
        private Produto _produto;

        [Required(ErrorMessage = "O campo CaracteristicaValor é obrigatório.")]
        [Display(Name = "Caract.Valor")]
        public CaracteristicaValor caracteristicaValor
        {
            get { return _caracteristicaValor; }
            set { _caracteristicaValor = value; RaisePropertyChanged("caracteristicaValor"); }

        }

        [Required(ErrorMessage = "O campo Produto é obrigatório.")]
        [Display(Name = "Produto")]
        public Produto produto
        {
            get { return _produto; }
            set { _produto = value; RaisePropertyChanged("produto"); }
        }

    }
}
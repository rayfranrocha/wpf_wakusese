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
    public class PedidoProduto : EntityBase
    {
        private Pedido _pedido { get; set; }
        private Produto _produto { get; set; }
        private Decimal _qtde { get; set; }
        private Decimal _precoPadrao { get; set; }
        private Decimal _precoPromocao { get; set; }
        private int _avaliacao { get; set; }


        [Required]
        [Display(Name = "Pedido")]
        public Pedido pedido
        {
            get { return _pedido; }
            set { _pedido = value; RaisePropertyChanged("pedido"); }
        }

        [Required]
        [Display(Name = "Produto")]
        public Produto produto
        {
            get { return _produto; }
            set { _produto = value; RaisePropertyChanged("produto"); }
        }

        [Required]
        [Display(Name = "Qtde")]
        [DisplayFormat(DataFormatString = "{0:n2}", NullDisplayText = "Sem valor.", ApplyFormatInEditMode = true)]
        public Decimal qtde
        {
            get { return _qtde; }
            set { _qtde = value; RaisePropertyChanged("qtde"); }
        }

        [Required]
        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:n2}", NullDisplayText = "Sem valor.", ApplyFormatInEditMode = true)]
        public Decimal precoPadrao
        {
            get { return _precoPadrao; }
            set { _precoPadrao = value; RaisePropertyChanged("precoPadrao"); }
        }

        [Display(Name = "Promoção")]
        [DisplayFormat(DataFormatString = "{0:n2}", NullDisplayText = "Sem promoção.", ApplyFormatInEditMode = true)]
        public Decimal precoPromocao
        {
            get { return _precoPromocao; }
            set { _precoPromocao = value; RaisePropertyChanged("precoPromocao"); }
        }

        [Required]
        [Display(Name = "Avaliação")]
        [Range(1, 5, ErrorMessage = "A avaliação dever está entre 1 e 5. Verifique!")]
        public int avaliacao
        {
            get { return _avaliacao; }
            set { _avaliacao = value; RaisePropertyChanged("avaliacao"); }
        }

        [NotMapped]
        public Decimal menorPreco
        {
            get
            {
                Decimal menorPreco = _precoPadrao;

                if (_precoPromocao != null && _precoPromocao > 0 && _precoPromocao < _precoPadrao)
                {
                    menorPreco = _precoPromocao;
                }

                return menorPreco;
            }
        }

        [NotMapped]
        public Decimal total
        {
            get
            {
                return _qtde * menorPreco;
            }
        }

    }
}

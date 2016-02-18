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
        private Pedido _pedido;
        private Produto _produto;
        private Decimal _qtdePedido;
        private Decimal _qtdeEntregue;
        private Decimal _precoPadrao;
        private Decimal _precoPromocao;
        private int _avaliacao;


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
        [Display(Name = "Qtde Pedido")]
        [DisplayFormat(DataFormatString = "{0:n2}", NullDisplayText = "Sem valor.", ApplyFormatInEditMode = true)]
        public Decimal qtdePedido
        {
            get { return _qtdePedido; }
            set { _qtdePedido = value; RaisePropertyChanged("qtdePedido"); }
        }

        [Required]
        [Display(Name = "Qtde Entregue")]
        [DisplayFormat(DataFormatString = "{0:n2}", NullDisplayText = "Sem valor.", ApplyFormatInEditMode = true)]
        public Decimal qtdeEntregue
        {
            get { return _qtdeEntregue; }
            set { _qtdeEntregue = value; RaisePropertyChanged("qtdeEntregue"); }
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

                if (_precoPromocao > 0 && _precoPromocao > 0 && _precoPromocao < _precoPadrao)
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
                return (_qtdePedido + _qtdeEntregue) * menorPreco;
            }
        }

    }
}

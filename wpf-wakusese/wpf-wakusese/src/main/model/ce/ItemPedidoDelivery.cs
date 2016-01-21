using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;

namespace wpf_wakusese.src.main.model.ce
{
    public class ItemPedidoDelivery : EntityBase
    {
        private PedidoDelivery _pedidoDelivery { get; set; }
        private Produto _produto { get; set; }
        private Decimal _qtde { get; set; }
        private Decimal _preco { get; set; }
        private int _avaliacao { get; set; }


        [Required]
        [Display(Name = "Pedido")]
        public PedidoDelivery pedidoDelivery
        {
            get { return _pedidoDelivery; }
            set { _pedidoDelivery = value; RaisePropertyChanged("pedidoDelivery"); }
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
        public Decimal preco
        {
            get { return _preco; }
            set { _preco = value; RaisePropertyChanged("preco"); }
        }

        [Required]
        [Display(Name = "Avaliação")]
        [Range(1, 5, ErrorMessage = "A avaliação dever está entre 1 e 5. Verifique!")]
        public int avaliacao
        {
            get { return _avaliacao; }
            set { _avaliacao = value; RaisePropertyChanged("avaliacao"); }
        }
    }
}

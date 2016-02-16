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
    public class Pedido : EntityBase
    {
        private Usuario _cliente;
        private int _formaPgto;
        private Boolean _isPago;
        private Boolean _isPontoFidelidade;
        private Boolean _isFidelConsumido;


        [Display(Name = "Cliente")]
        public Usuario cliente
        {
            get
            {
                //if (_cliente == null) { return new Usuario(); }

                return _cliente;
            }
            set { _cliente = value; RaisePropertyChanged("cliente"); }
        }

        [Display(Name = "Forma Pgto.")]
        public int formaPagto
        {
            get { return _formaPgto; }
            set { _formaPgto = value; RaisePropertyChanged("formaPgto"); }
        }

        [Display(Name = "Pago?")]
        public Boolean isPago
        {
            get { return _isPago; }
            set { _isPago = value; RaisePropertyChanged("isPago"); }
        }

        [Display(Name = "PontoFidelidade?")]
        public Boolean isPontoFidelidade
        {
            get { return _isPontoFidelidade; }
            set { _isPontoFidelidade = value; RaisePropertyChanged("isPontoFidelidade"); }
        }

        [Display(Name = "P. Fidelid. Consumido?")]
        public Boolean isFidelConsumido
        {
            get { return _isFidelConsumido; }
            set { _isFidelConsumido = value; RaisePropertyChanged("isFidelConsumido"); }
        }

        [NotMapped]
        public List<PedidoProduto> listaPedidoProduto = new List<PedidoProduto>();

        [NotMapped]
        public Decimal total
        {
            get
            {
                Decimal r = 0;
                foreach (var item in listaPedidoProduto)
                {
                    r += item.total;
                }
                return r;
            }
        }


    }
}

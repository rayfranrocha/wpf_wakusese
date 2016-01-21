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
    public class PedidoDelivery : EntityBase
    {
        private Empresa _empresa { get; set; }
        private int _formaPgto { get; set; }
        private Boolean _isPago { get; set; }
        private DateTime _checking { get; set; }
        private DateTime _checkout { get; set; }


        [Required]
        [Display(Name = "Empresa")]
        public Empresa empresa
        {
            get { return _empresa; }
            set { _empresa = value; RaisePropertyChanged("empresa"); }
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

        [Display(Name = "Checking")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime checking
        {
            get { return _checking; }
            set { _checking = value; RaisePropertyChanged("checking"); }
        }

        [Display(Name = "Checkout")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime checkout
        {
            get { return _checkout; }
            set { _checkout = value; RaisePropertyChanged("checkout"); }
        }

    }
}

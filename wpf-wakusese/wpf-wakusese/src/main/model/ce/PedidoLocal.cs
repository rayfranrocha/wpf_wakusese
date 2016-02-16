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
    public class PedidoLocal : EntityBase
    {
        private Empresa _empresa;
        private Pedido _pedido;
        private String _mesa;
        private DateTime _checkin;
        private DateTime _checkout;

        [Required]
        [Display(Name = "Empresa")]
        public Empresa empresa
        {
            get { return _empresa; }
            set { _empresa = value; RaisePropertyChanged("empresa"); }
        }

        [Required]
        [Display(Name = "Pedido")]
        public Pedido pedido
        {
            get { return _pedido; }
            set { _pedido = value; RaisePropertyChanged("pedido"); }
        }

        [Display(Name = "Mesa")]
        public String mesa
        {
            get { return _mesa; }
            set { _mesa = value; RaisePropertyChanged("mesa"); }
        }

        [Display(Name = "Check-in")]
        public DateTime checkin
        {
            get { return _checkin; }
            set { _checkin = value; RaisePropertyChanged("checkin"); }
        }

        [Display(Name = "Check-out")]
        public DateTime checkout
        {
            get { return _checkout; }
            set { _checkout = value; RaisePropertyChanged("checkout"); }
        }

        [NotMapped]
        public String status
        {
            get { return checkout < checkin ? "Consumindo" : "Quitado"; }

        }

    }
}

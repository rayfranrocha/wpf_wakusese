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
        private Pedido _pedido { get; set; }
        private DateTime _horaPedido { get; set; }
        private DateTime _horaLiberacao { get; set; }
        private DateTime _horaEntrega { get; set; }

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


        [Display(Name = "Hr.Pedido")]
        public DateTime horaPedido
        {
            get { return _horaPedido; }
            set { _horaPedido = value; RaisePropertyChanged("horaPedido"); }
        }

        [Display(Name = "Hr.Liberação")]
        public DateTime horaLiberacao
        {
            get { return _horaLiberacao; }
            set { _horaLiberacao = value; RaisePropertyChanged("horaLiberacao"); }
        }

        [Display(Name = "Hr.Entrega")]
        public DateTime horaEntrega
        {
            get { return _horaEntrega; }
            set { _horaEntrega = value; RaisePropertyChanged("horaEntrega"); }
        }

    }
}

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
    public class PedidoAtendente : EntityBase
    {
        private Pedido _pedido { get; set; }
        private Usuario _atendente { get; set; }

        [Required]
        [Display(Name = "Pedido")]
        
        public Pedido pedido {
            get { return _pedido; }
            set { _pedido = value; RaisePropertyChanged("pedido"); }
        }

        [Required]
        [Display(Name = "Atendente")]
        public Usuario atendente 
        {
            get { return _atendente; }
            set { _atendente = value; RaisePropertyChanged("atendente"); }
        }

    }
}

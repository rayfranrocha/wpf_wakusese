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
        private Usuario _usuarioAtendente { get; set; }
        private Perfil _perfil { get; set; }

        [Required]
        [Display(Name = "Pedido")]
        [Index("IX_PedidoAtendente", Order = 1, IsUnique = true)]
        public Pedido pedido
        {
            get { return _pedido; }
            set { _pedido = value; RaisePropertyChanged("pedido"); }
        }

        [Required]
        [Display(Name = "Atendente")]
        [Index("IX_PedidoAtendente", Order = 2, IsUnique = true)]
        public Usuario usuarioAtendente
        {
            get { return _usuarioAtendente; }
            set { _usuarioAtendente = value; RaisePropertyChanged("usuarioAtendente"); }
        }

        [Required]
        [Display(Name = "Perfil")]
        [Index("IX_PedidoAtendente", Order = 3, IsUnique = true)]
        public Perfil perfil
        {
            get { return _perfil; }
            set { _perfil = value; RaisePropertyChanged("perfil"); }
        }


    }
}

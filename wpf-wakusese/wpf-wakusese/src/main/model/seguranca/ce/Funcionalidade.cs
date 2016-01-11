using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wpf_wakusese.src.main._utils;


namespace wpf_wakusese.src.main.model.seguranca
{
    public class Funcionalidade : EntityBase
    {
        [Display(Name = "Nome")]
        public String nome { get; set; }
    }
}

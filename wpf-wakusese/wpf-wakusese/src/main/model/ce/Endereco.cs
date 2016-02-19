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
    public class Endereco : EntityBase
    {
        private Decimal _latitude;
        private Decimal _longitude;
        private String _logradouro;
        private String _pontoReferencia;
        private String _cep;

        [Display(Name = "Latitude")]
        public Decimal latitude
        {
            get { return _latitude; }
            set { _latitude = value; RaisePropertyChanged("latitude"); }
        }

        [Display(Name = "Longitude")]
        public Decimal longitude
        {
            get { return _longitude; }
            set { _longitude = value; RaisePropertyChanged("longitude"); }
        }

        [Display(Name = "Logradouro")]
        public String logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; RaisePropertyChanged("logradouro"); }
        }

        [Display(Name = "Ponto Referência")]
        public String pontoReferencia
        {
            get { return _pontoReferencia; }
            set { _pontoReferencia = value; RaisePropertyChanged("pontoReferencia"); }
        }

        [Display(Name = "CEP")]
        public String cep
        {
            get { return _cep; }
            set { _cep = value; RaisePropertyChanged("cep"); }
        }

        public override string ToString()
        {
            return "Cep: " + cep + ", Logradouro: " + logradouro;
        }

    }
}

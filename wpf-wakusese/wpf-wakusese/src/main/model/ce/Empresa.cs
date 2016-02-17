using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wpf_wakusese.src.main._utils;
using System.Runtime.Serialization;

namespace wpf_wakusese.src.main.model.ce
{
    //comentario rayfran
    [DataContract(IsReference = true)]
    public class Empresa : EntityBase
    {
        public Empresa()
        {
            endereco = new Endereco();
        }

        // comentario teste 

        private String _cnpj;
        private String _nome;
        private Decimal _percTxServico;
        private Decimal _valorTxEntrega;
        private Endereco _endereco;

        [Display(Name = "CNPJ")]
        public String cnpj
        {
            get { return _cnpj; }
            set { _cnpj = value; RaisePropertyChanged("cnpj"); }
        }


        [Display(Name = "Nome")]
        [DataMember]
        public String nome
        {
            get { return _nome; }
            set { _nome = value; RaisePropertyChanged("nome"); }
        }

        [Display(Name = "% Tx Serv.")]
        [Range(0.0, 100, ErrorMessage = "% Deve ser entre 0 e 100%. Verifique!")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false, NullDisplayText = "Sem valor")]
        public Decimal percTxServico
        {
            get { return _percTxServico; }
            set { _percTxServico = value; RaisePropertyChanged("percTxServico"); }
        }



        [Display(Name = "R$ Tx Entrega")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Valor deve ser maior que zero. Verifique!")]
        [DisplayFormat(DataFormatString = "{0:N2}",
            ApplyFormatInEditMode = false,
            NullDisplayText = "Sem preço")]
        public Decimal valorTxEntrega
        {
            get { return _valorTxEntrega; }
            set { _valorTxEntrega = value; RaisePropertyChanged("valorTxEntrega"); }
        }



        [Display(Name = "Endereço")]
        public Endereco endereco
        {
            get { return _endereco; }
            set { _endereco = value; RaisePropertyChanged("endereco"); }
        }
    }
}

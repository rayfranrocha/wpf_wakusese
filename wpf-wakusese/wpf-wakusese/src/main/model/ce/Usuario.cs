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
    [DataContract(IsReference = true)]
    public class Usuario : EntityBase
    {
        private Empresa _ultimaEmpresa;
        private Endereco _endereco;
        private String _email;
        private String _telefone;
        private String _imeiTelefone;
        private String _senha;
        private String _nome;
        private String _facebook;
        private String _instagram;
        private DateTime _dataNascimento;
        private bool _isPermanecerLogado;

        [Display(Name = "Email")]
        [Required]
        [Index("IX_UsuarioEmail", IsUnique = true)]
        public String email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged("email"); }
        }

        [Display(Name = "Facebook")]
        public String facebook
        {
            get { return _facebook; }
            set { _facebook = value; RaisePropertyChanged("facebook"); }
        }

        [Display(Name = "Instagram")]
        public String instagram
        {
            get { return _instagram; }
            set { _instagram = value; RaisePropertyChanged("instagram"); }
        }

        [Display(Name = "Senha")]
        public String senha
        {
            get { return _senha; }
            set { _senha = value; RaisePropertyChanged("senha"); }
        }

        [Display(Name = "Nome")]
        public String nome
        {
            get { return _nome; }
            set { _nome = value; RaisePropertyChanged("nome"); }
        }

        [Index("IX_UsuarioMacTelefone", IsUnique = true)]
        [Display(Name = "IMEI")]
        public String imeiTelefone
        {
            get { return _imeiTelefone; }
            set { _imeiTelefone = value; RaisePropertyChanged("imeiTelefone"); }
        }

        [Display(Name = "Telefone")]
        public String telefone
        {
            get { return _telefone; }
            set { _telefone = value; RaisePropertyChanged("telefone"); }
        }

        [Display(Name = "Última Empresa")]
        [DataMember]
        public Empresa ultimaEmpresa
        {
            get { return _ultimaEmpresa; }
            set { _ultimaEmpresa = value; RaisePropertyChanged("ultimaEmpresa"); }
        }

        [Display(Name = "Nascimento")]
        public DateTime dataNascimento
        {
            get { return _dataNascimento; }
            set { _dataNascimento = value; RaisePropertyChanged("dataNascimento"); }
        }

        [Display(Name = "Permanecer Logado?")]
        public bool isPermanecerLogado
        {
            get { return _isPermanecerLogado; }
            set { _isPermanecerLogado = value; RaisePropertyChanged("isPermanecerLogado"); }
        }

        [Display(Name = "Endereço")]
        public Endereco endereco
        {
            get { return _endereco; }
            set { _endereco = value; RaisePropertyChanged("endereco"); }
        }

    }
}

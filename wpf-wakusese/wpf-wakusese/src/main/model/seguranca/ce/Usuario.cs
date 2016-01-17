using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.cadastros.ce;


namespace wpf_wakusese.src.main.model.seguranca.ce
{
    public class Usuario : EntityBase
    {
        private String _email;
        private String _senha;
        private String _macTelefone;
        private String _telefone;

        private bool _isPermanecerLogado;
        private Empresa _ultimaEmpresa = new Empresa();

        [Display(Name = "Email")]
        public String email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged("email"); }
        }

        [Display(Name = "Senha")]
        public String senha
        {
            get { return _senha; }
            set { _senha = value; RaisePropertyChanged("senha"); }
        }

        [Display(Name = "MacTelefone")]
        public String macTelefone
        {
            get { return _macTelefone; }
            set { _macTelefone = value; RaisePropertyChanged("macTelefone"); }
        }

        [Display(Name = "Telefone")]
        public String telefone
        {
            get { return _telefone; }
            set { _telefone = value; RaisePropertyChanged("telefone"); }
        }

        [Display(Name = "Última Empresa")]
        public Empresa ultimaEmpresa
        {
            get { return _ultimaEmpresa; }
            set { _ultimaEmpresa = value; RaisePropertyChanged("ultimaEmpresa"); }
        }

        [Display(Name = "Permanecer Logado?")]
        public bool isPermanecerLogado
        {
            get { return _isPermanecerLogado; }
            set { _isPermanecerLogado = value; RaisePropertyChanged("isPermanecerLogado"); }
        }

    }
}

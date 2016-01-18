using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.cadastros.bo;
using wpf_wakusese.src.main.model.cadastros.ce;
using wpf_wakusese.src.main.model.seguranca.ce;

namespace wpf_wakusese.src.main.model.seguranca.bo
{
    public class BOUsuario : BoPadrao<Usuario>
    {

        BOEmpresa boEmpresa;

        public BOUsuario() : base() {
            boEmpresa = new BOEmpresa(this._DbContext);
        }

        public void ExemploVerificaUsuarioEmpresa_seNaoExistir_CriaOsDois(Usuario usu, Empresa emp) {

            try
            {

            Usuario usuario = this.ObterPrimeiro(x => x.email == usu.email);
            }
            catch (Exception)
            {
                this.InserirOuAlterar(usu);
            }

            try
            {
                Empresa empresa = boEmpresa.ObterPrimeiro(x => x.nome == emp.nome);
            }
            catch (Exception)
            {
                boEmpresa.InserirOuAlterar(emp);
            }

            this.Commit();

        }

    }
}

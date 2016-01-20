using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main._utils.bo;
using wpf_wakusese.src.main.model.bo;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.model.servicos
{
    public class SegurancaServico
    {
        private EFDBContext dbContext;

        private UsuarioBO boUsuario;
        private EmpresaBO boEmpresa;
        private GenericoBO<Funcionalidade> funcionalidadeServico;

        public SegurancaServico()
        {
            dbContext = new EFDBContext();
            boUsuario = new UsuarioBO(dbContext);
            boEmpresa = new EmpresaBO(dbContext);
            funcionalidadeServico = new GenericoBO<Funcionalidade>(dbContext);
        }

        public void ExemploVerificaUsuarioEmpresa_seNaoExistir_CriaOsDois(Usuario usu, Empresa emp)
        {

            try
            {

                Usuario usuario = boUsuario.ObterPrimeiro(x => x.email == usu.email);
            }
            catch (Exception)
            {
                boUsuario.InserirOuAlterar(usu);
            }

            try
            {
                Empresa empresa = boEmpresa.ObterPrimeiro(x => x.nome == emp.nome);
            }
            catch (Exception)
            {
                boEmpresa.InserirOuAlterar(emp);
            }

            dbContext.SaveChanges();

        }

    }
}

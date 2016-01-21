using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.bo;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.model.servicos
{
    public class SegurancaServico
    {
        private EFDBContext dbContext;

        private BO_Usuario boUsuario;
        private BO_Empresa boEmpresa;
        private GenericoBO<Funcionalidade> funcionalidadeServico;

        public SegurancaServico()
        {
            dbContext = new EFDBContext();
            boUsuario = new BO_Usuario(dbContext);
            boEmpresa = new BO_Empresa(dbContext);
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

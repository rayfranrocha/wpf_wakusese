﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.bo;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.model.servicos
{
    public class DominioSeguranca
    {
        private EFDBContext dbContext;

        private BO_Usuario boUsuario;
        private BO_Empresa boEmpresa;

        public DominioSeguranca()
        {
            dbContext = EFDBContext.Instance;
            boUsuario = new BO_Usuario();
            boEmpresa = new BO_Empresa();
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

        /// <summary>
        /// Este método é resposável por autenticar um usuario (fazer login e recuperar seus acessos)
        /// <para> 1. Verifica credenciais do usuário (telefone ou email + senha) </para>
        /// <para>2. Recupera a lista de Perfil a partir do Usuario + Empresa </para>
        /// <para>3. A partir da lista de perfil, adiciona ao Usuario a lista de Funcionalidade que o mesmo tem acesso </para>
        /// </summary>
        /// <returns>Usuario</returns>
        public Usuario doAutenticarUsuario(String telOrEmail,String senha)
        {
            Usuario r = boUsuario.ObterListaObjeto(telOrEmail, senha);

            return r;
        }

    }
}

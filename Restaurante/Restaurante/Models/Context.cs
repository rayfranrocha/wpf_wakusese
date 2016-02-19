using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Formatters;
using System.IO;
using System.Drawing;

namespace Restaurante
{
    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public DbSet<CE_Caracteristica> Caracteristica { get; set; }
        public DbSet<CE_CaracteristicaValor> CaracteristicaValor { get; set; }
        public DbSet<CE_Categoria> Categoria { get; set; }
        public DbSet<CE_Empresa> Empresa { get; set; }
        public DbSet<CE_Endereco> Endereco { get; set; }
        public DbSet<CE_Funcionalidade> Funcionalidade { get; set; }
        public DbSet<CE_Pedido> Pedido { get; set; }
        public DbSet<CE_PedidoDelivery> PedidoDelivery { get; set; }
        public DbSet<CE_PedidoLocal> PedidoLocal { get; set; }
        public DbSet<CE_PedidoProduto> PedidoProduto { get; set; }
        public DbSet<CE_Perfil> Perfil { get; set; }
        public DbSet<CE_PerfilFuncionalidade> PerfilFuncionalidade { get; set; }
        public DbSet<CE_ProdCaractValor> ProdCaractValor { get; set; }
        public DbSet<CE_Produto> Produto { get; set; }
        public DbSet<CE_Promocao> Promocao { get; set; }
        public DbSet<CE_Usuario> Usuario { get; set; }
        public DbSet<CE_ValePresente> ValePresente { get; set; }
        public DbSet<CE_ValePresenteAvulso> ValePresenteAvulso { get; set; }
        public DbSet<CE_UsuarioPerfil> UsuarioPerfil { get; set; }
        public DbSet<CE_PerfilPadraoEnum> PerfilPadraoEnum { get; set; }

        public IEnumerable GetEndereco()
        {
            Context db = new Context();
            var query = from category in db.Endereco
                        select new
                        {
                            endeId = category.endeId,
                            endeLograd = category.endeLograd
                        };
            return query.ToList();
        }

        public IEnumerable GetUsuario()
        {
            Context db = new Context();
            var query = from category in db.Usuario
                        select new
                        {
                            usuId = category.usuId,
                            usuNome = category.usuNome
                        };
            return query.ToList();
        }

        public IEnumerable GetPedido()
        {
            Context db = new Context();
            var query = from category in db.Pedido
                        select new
                        {
                            pedidoId = category.pedidoId,
                            pedidoFormPgto = category.pedidoFormPgto
                        };
            return query.ToList();
        }

        public IEnumerable GetProduto()
        {
            Context db = new Context();
            var query = from category in db.Produto
                        select new
                        {
                            prodId = category.prodId,
                            prodNome = category.prodNome
                        };
            return query.ToList();
        }

        public IEnumerable GetEmpresa()
        {
            Context db = new Context();
            var query = from category in db.Empresa
                        select new
                        {
                            empresaId = category.empresaId,
                            empresaNome = category.empresaNome
                        };
            return query.ToList();
        }

        public IEnumerable GetCategoria()
        {
            Context db = new Context();
            var query = from category in db.Categoria
                        select new
                        {
                            categId = category.categId,
                            categNome = category.categNome
                        };
            return query.ToList();
        }

        public IEnumerable GetCaracteristica()
        {
            Context db = new Context();
            var query = from category in db.Caracteristica
                        select new
                        {
                            caractId = category.caractId,
                            caractNome = category.caractNome
                        };
            return query.ToList();
        }

        public IEnumerable GetCaracteristicaValor()
        {
            Context db = new Context();
            var query = from category in db.CaracteristicaValor
                        select new
                        {
                            caractValId = category.caractValId,
                            caractValValor = category.caractValValor

                        };

            return query.ToList();
        }

        public object GetPerfilPadrao()
        {
            Context db = new Context();
            var query = from category in db.PerfilPadraoEnum
                        select new
                        {
                            perfilPadraoEnumId = category.perfilPadraoEnumId,
                            perfilPadraoEnumTipo = category.perfilPadraoEnumTipo
                        };

            return query.ToList();
        }

        public object GetPerfil()
        {
            Context db = new Context();
            var query = from category in db.Perfil
                        select new
                        {
                            perfilId = category.perfilId,
                            perfilPadraoEnumTipo = category.PerfilPadraoEnum.perfilPadraoEnumTipo
                        };

            return query.ToList();
        }

    

    }
}
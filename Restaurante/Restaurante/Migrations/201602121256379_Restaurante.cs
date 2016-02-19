namespace Restaurante.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restaurante : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CE_Caracteristica",
                c => new
                    {
                        caractId = c.Int(nullable: false, identity: true),
                        caractNome = c.String(nullable: false),
                        caractEmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.caractId)
                .ForeignKey("dbo.CE_Empresa", t => t.caractEmpresaId, cascadeDelete: true)
                .Index(t => t.caractEmpresaId);
            
            CreateTable(
                "dbo.CE_CaracteristicaValor",
                c => new
                    {
                        caractValId = c.Int(nullable: false, identity: true),
                        caractValValor = c.String(nullable: false),
                        caractValorCaractId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.caractValId)
                .ForeignKey("dbo.CE_Caracteristica", t => t.caractValorCaractId, cascadeDelete: true)
                .Index(t => t.caractValorCaractId);
            
            CreateTable(
                "dbo.CE_ProdCaractValor",
                c => new
                    {
                        prodCaractValorId = c.Int(nullable: false, identity: true),
                        ProdCaractValorProdtId = c.Int(nullable: false),
                        ProdCaractValorCaracteristicaValorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.prodCaractValorId)
                .ForeignKey("dbo.CE_CaracteristicaValor", t => t.ProdCaractValorCaracteristicaValorId, cascadeDelete: true)
                .ForeignKey("dbo.CE_Produto", t => t.ProdCaractValorProdtId, cascadeDelete: true)
                .Index(t => t.ProdCaractValorProdtId)
                .Index(t => t.ProdCaractValorCaracteristicaValorId);
            
            CreateTable(
                "dbo.CE_Produto",
                c => new
                    {
                        prodId = c.Int(nullable: false, identity: true),
                        prodNome = c.String(),
                        prodDesc = c.String(),
                        prodImg1 = c.Binary(),
                        prodImg2 = c.Binary(),
                        prodImg3 = c.Binary(),
                        prodPreco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        prodAvaliacaoMedia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.prodId);
            
            CreateTable(
                "dbo.CE_PedidoProduto",
                c => new
                    {
                        pedProdId = c.Int(nullable: false, identity: true),
                        pedProdisItensCarr = c.Boolean(nullable: false),
                        pedProdQtde = c.Decimal(nullable: false, precision: 18, scale: 2),
                        pedProdPrecPromo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        pedProdPrecPadrao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        pedProdGetTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        pedProdProdutoId = c.Int(nullable: false),
                        pedProdPedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pedProdId)
                .ForeignKey("dbo.CE_Pedido", t => t.pedProdPedidoId, cascadeDelete: true)
                .ForeignKey("dbo.CE_Produto", t => t.pedProdProdutoId, cascadeDelete: true)
                .Index(t => t.pedProdProdutoId)
                .Index(t => t.pedProdPedidoId);
            
            CreateTable(
                "dbo.CE_Pedido",
                c => new
                    {
                        pedidoId = c.Int(nullable: false, identity: true),
                        pedidoFormPgto = c.Int(nullable: false),
                        pedidoIsPago = c.Boolean(nullable: false),
                        pedidoIsPontoFidelidade = c.Boolean(nullable: false),
                        pedidoIsFidelidConsumido = c.Boolean(nullable: false),
                        pedidoUsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pedidoId)
                .ForeignKey("dbo.CE_Usuario", t => t.pedidoUsuarioId, cascadeDelete: true)
                .Index(t => t.pedidoUsuarioId);
            
            CreateTable(
                "dbo.CE_PedidoDelivery",
                c => new
                    {
                        pedDeliId = c.Int(nullable: false, identity: true),
                        pedDeliHoraPedido = c.DateTime(nullable: false),
                        pedDeliHoraLiberacao = c.DateTime(nullable: false),
                        pedDeliHoraEntrega = c.DateTime(nullable: false),
                        pedDeliEmpresaId = c.Int(nullable: false),
                        pedDeliPedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pedDeliId)
                .ForeignKey("dbo.CE_Empresa", t => t.pedDeliEmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.CE_Pedido", t => t.pedDeliPedidoId, cascadeDelete: true)
                .Index(t => t.pedDeliEmpresaId)
                .Index(t => t.pedDeliPedidoId);
            
            CreateTable(
                "dbo.CE_Empresa",
                c => new
                    {
                        empresaId = c.Int(nullable: false, identity: true),
                        empresaCNPJ = c.Int(nullable: false),
                        empresaNome = c.String(),
                        empresaLocal = c.String(),
                        empresaPercTxServico = c.Decimal(nullable: false, precision: 18, scale: 2),
                        empresaValorTxEntrega = c.Decimal(nullable: false, precision: 18, scale: 2),
                        empresaEnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.empresaId)
                .ForeignKey("dbo.CE_Endereco", t => t.empresaEnderecoId, cascadeDelete: true)
                .Index(t => t.empresaEnderecoId);
            
            CreateTable(
                "dbo.CE_Categoria",
                c => new
                    {
                        categId = c.Int(nullable: false, identity: true),
                        categImg = c.Byte(nullable: false),
                        categNome = c.String(),
                        categEmpresaId = c.Int(nullable: false),
                        categCategoriaPai_categId = c.Int(),
                    })
                .PrimaryKey(t => t.categId)
                .ForeignKey("dbo.CE_Categoria", t => t.categCategoriaPai_categId)
                .ForeignKey("dbo.CE_Empresa", t => t.categEmpresaId, cascadeDelete: true)
                .Index(t => t.categEmpresaId)
                .Index(t => t.categCategoriaPai_categId);
            
            CreateTable(
                "dbo.CE_Endereco",
                c => new
                    {
                        endeId = c.Int(nullable: false, identity: true),
                        endeLati = c.Int(nullable: false),
                        endeLongi = c.Int(nullable: false),
                        endeLograd = c.String(),
                        endePontoRefer = c.String(),
                        endeCEP = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.endeId);
            
            CreateTable(
                "dbo.CE_Usuario",
                c => new
                    {
                        usuId = c.Int(nullable: false, identity: true),
                        usuEmail = c.String(),
                        usuTelef = c.Int(nullable: false),
                        usuImeiTelef = c.String(),
                        usuSenha = c.String(),
                        usuNome = c.String(),
                        usuDataNasc = c.DateTime(nullable: false),
                        usuFacebook = c.String(),
                        usuInstagram = c.String(),
                        usuIsPermanLogado = c.Boolean(nullable: false),
                        usuNivelAcesso = c.String(),
                        usuarioEnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.usuId)
                .ForeignKey("dbo.CE_Endereco", t => t.usuarioEnderecoId, cascadeDelete: false)
                .Index(t => t.usuarioEnderecoId);
            
            CreateTable(
                "dbo.CE_UsuarioPerfil",
                c => new
                    {
                        usuarioPerfilId = c.Int(nullable: false, identity: true),
                        usuarioPerfilUsuarioId = c.Int(nullable: false),
                        usuarioPerfilPerfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.usuarioPerfilId)
                .ForeignKey("dbo.CE_Perfil", t => t.usuarioPerfilPerfilId, cascadeDelete: true)
                .ForeignKey("dbo.CE_Usuario", t => t.usuarioPerfilUsuarioId, cascadeDelete: true)
                .Index(t => t.usuarioPerfilUsuarioId)
                .Index(t => t.usuarioPerfilPerfilId);
            
            CreateTable(
                "dbo.CE_Perfil",
                c => new
                    {
                        perfilId = c.Int(nullable: false, identity: true),
                        perfilEmpresaId = c.Int(nullable: false),
                        perfilPadraoEnumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.perfilId)
                .ForeignKey("dbo.CE_Empresa", t => t.perfilEmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.CE_PerfilPadraoEnum", t => t.perfilPadraoEnumId, cascadeDelete: true)
                .Index(t => t.perfilEmpresaId)
                .Index(t => t.perfilPadraoEnumId);
            
            CreateTable(
                "dbo.CE_PerfilPadraoEnum",
                c => new
                    {
                        perfilPadraoEnumId = c.Int(nullable: false, identity: true),
                        perfilPadraoEnumTipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.perfilPadraoEnumId);
            
            CreateTable(
                "dbo.CE_PedidoLocal",
                c => new
                    {
                        pedLocalId = c.Int(nullable: false, identity: true),
                        pedLocalNome = c.String(),
                        pedLocalCheckin = c.DateTime(nullable: false),
                        pedLocalCheckout = c.DateTime(nullable: false),
                        PedidoLocalEmpresaId = c.Int(nullable: false),
                        PedidoLocalPedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pedLocalId)
                .ForeignKey("dbo.CE_Empresa", t => t.PedidoLocalEmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.CE_Pedido", t => t.PedidoLocalPedidoId, cascadeDelete: true)
                .Index(t => t.PedidoLocalEmpresaId)
                .Index(t => t.PedidoLocalPedidoId);
            
            CreateTable(
                "dbo.CE_ValePresente",
                c => new
                    {
                        valePresenteId = c.Int(nullable: false, identity: true),
                        valePresentevalor = c.Double(nullable: false),
                        valePresenteEmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.valePresenteId)
                .ForeignKey("dbo.CE_Empresa", t => t.valePresenteEmpresaId, cascadeDelete: true)
                .Index(t => t.valePresenteEmpresaId);
            
            CreateTable(
                "dbo.CE_ValePresenteAvulso",
                c => new
                    {
                        valePresId = c.Int(nullable: false, identity: true),
                        valePresNome = c.String(),
                        valePresEmail = c.String(),
                        valePresValor = c.Int(nullable: false),
                        valePresenteAvulsoEmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.valePresId)
                .ForeignKey("dbo.CE_Empresa", t => t.valePresenteAvulsoEmpresaId, cascadeDelete: true)
                .Index(t => t.valePresenteAvulsoEmpresaId);
            
            CreateTable(
                "dbo.CE_Promocao",
                c => new
                    {
                        promoId = c.Int(nullable: false, identity: true),
                        promoInicio = c.DateTime(nullable: false),
                        promoFim = c.DateTime(nullable: false),
                        promoPreco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        promocaoProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.promoId)
                .ForeignKey("dbo.CE_Produto", t => t.promocaoProdutoId, cascadeDelete: true)
                .Index(t => t.promocaoProdutoId);
            
            CreateTable(
                "dbo.CE_Funcionalidade",
                c => new
                    {
                        funcionId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.funcionId);
            
            CreateTable(
                "dbo.CE_PerfilFuncionalidade",
                c => new
                    {
                        perfilFuncioId = c.Int(nullable: false, identity: true),
                        perfilFuncioFuncioId = c.Int(nullable: false),
                        perfilFuncioPerfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.perfilFuncioId)
                .ForeignKey("dbo.CE_Funcionalidade", t => t.perfilFuncioFuncioId, cascadeDelete: true)
                .ForeignKey("dbo.CE_Perfil", t => t.perfilFuncioPerfilId, cascadeDelete: true)
                .Index(t => t.perfilFuncioFuncioId)
                .Index(t => t.perfilFuncioPerfilId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CE_PerfilFuncionalidade", "perfilFuncioPerfilId", "dbo.CE_Perfil");
            DropForeignKey("dbo.CE_PerfilFuncionalidade", "perfilFuncioFuncioId", "dbo.CE_Funcionalidade");
            DropForeignKey("dbo.CE_Caracteristica", "caractEmpresaId", "dbo.CE_Empresa");
            DropForeignKey("dbo.CE_ProdCaractValor", "ProdCaractValorProdtId", "dbo.CE_Produto");
            DropForeignKey("dbo.CE_Promocao", "promocaoProdutoId", "dbo.CE_Produto");
            DropForeignKey("dbo.CE_PedidoProduto", "pedProdProdutoId", "dbo.CE_Produto");
            DropForeignKey("dbo.CE_PedidoProduto", "pedProdPedidoId", "dbo.CE_Pedido");
            DropForeignKey("dbo.CE_Pedido", "pedidoUsuarioId", "dbo.CE_Usuario");
            DropForeignKey("dbo.CE_PedidoDelivery", "pedDeliPedidoId", "dbo.CE_Pedido");
            DropForeignKey("dbo.CE_PedidoDelivery", "pedDeliEmpresaId", "dbo.CE_Empresa");
            DropForeignKey("dbo.CE_ValePresenteAvulso", "valePresenteAvulsoEmpresaId", "dbo.CE_Empresa");
            DropForeignKey("dbo.CE_ValePresente", "valePresenteEmpresaId", "dbo.CE_Empresa");
            DropForeignKey("dbo.CE_PedidoLocal", "PedidoLocalPedidoId", "dbo.CE_Pedido");
            DropForeignKey("dbo.CE_PedidoLocal", "PedidoLocalEmpresaId", "dbo.CE_Empresa");
            DropForeignKey("dbo.CE_Empresa", "empresaEnderecoId", "dbo.CE_Endereco");
            DropForeignKey("dbo.CE_UsuarioPerfil", "usuarioPerfilUsuarioId", "dbo.CE_Usuario");
            DropForeignKey("dbo.CE_UsuarioPerfil", "usuarioPerfilPerfilId", "dbo.CE_Perfil");
            DropForeignKey("dbo.CE_Perfil", "perfilPadraoEnumId", "dbo.CE_PerfilPadraoEnum");
            DropForeignKey("dbo.CE_Perfil", "perfilEmpresaId", "dbo.CE_Empresa");
            DropForeignKey("dbo.CE_Usuario", "usuarioEnderecoId", "dbo.CE_Endereco");
            DropForeignKey("dbo.CE_Categoria", "categEmpresaId", "dbo.CE_Empresa");
            DropForeignKey("dbo.CE_Categoria", "categCategoriaPai_categId", "dbo.CE_Categoria");
            DropForeignKey("dbo.CE_ProdCaractValor", "ProdCaractValorCaracteristicaValorId", "dbo.CE_CaracteristicaValor");
            DropForeignKey("dbo.CE_CaracteristicaValor", "caractValorCaractId", "dbo.CE_Caracteristica");
            DropIndex("dbo.CE_PerfilFuncionalidade", new[] { "perfilFuncioPerfilId" });
            DropIndex("dbo.CE_PerfilFuncionalidade", new[] { "perfilFuncioFuncioId" });
            DropIndex("dbo.CE_Promocao", new[] { "promocaoProdutoId" });
            DropIndex("dbo.CE_ValePresenteAvulso", new[] { "valePresenteAvulsoEmpresaId" });
            DropIndex("dbo.CE_ValePresente", new[] { "valePresenteEmpresaId" });
            DropIndex("dbo.CE_PedidoLocal", new[] { "PedidoLocalPedidoId" });
            DropIndex("dbo.CE_PedidoLocal", new[] { "PedidoLocalEmpresaId" });
            DropIndex("dbo.CE_Perfil", new[] { "perfilPadraoEnumId" });
            DropIndex("dbo.CE_Perfil", new[] { "perfilEmpresaId" });
            DropIndex("dbo.CE_UsuarioPerfil", new[] { "usuarioPerfilPerfilId" });
            DropIndex("dbo.CE_UsuarioPerfil", new[] { "usuarioPerfilUsuarioId" });
            DropIndex("dbo.CE_Usuario", new[] { "usuarioEnderecoId" });
            DropIndex("dbo.CE_Categoria", new[] { "categCategoriaPai_categId" });
            DropIndex("dbo.CE_Categoria", new[] { "categEmpresaId" });
            DropIndex("dbo.CE_Empresa", new[] { "empresaEnderecoId" });
            DropIndex("dbo.CE_PedidoDelivery", new[] { "pedDeliPedidoId" });
            DropIndex("dbo.CE_PedidoDelivery", new[] { "pedDeliEmpresaId" });
            DropIndex("dbo.CE_Pedido", new[] { "pedidoUsuarioId" });
            DropIndex("dbo.CE_PedidoProduto", new[] { "pedProdPedidoId" });
            DropIndex("dbo.CE_PedidoProduto", new[] { "pedProdProdutoId" });
            DropIndex("dbo.CE_ProdCaractValor", new[] { "ProdCaractValorCaracteristicaValorId" });
            DropIndex("dbo.CE_ProdCaractValor", new[] { "ProdCaractValorProdtId" });
            DropIndex("dbo.CE_CaracteristicaValor", new[] { "caractValorCaractId" });
            DropIndex("dbo.CE_Caracteristica", new[] { "caractEmpresaId" });
            DropTable("dbo.CE_PerfilFuncionalidade");
            DropTable("dbo.CE_Funcionalidade");
            DropTable("dbo.CE_Promocao");
            DropTable("dbo.CE_ValePresenteAvulso");
            DropTable("dbo.CE_ValePresente");
            DropTable("dbo.CE_PedidoLocal");
            DropTable("dbo.CE_PerfilPadraoEnum");
            DropTable("dbo.CE_Perfil");
            DropTable("dbo.CE_UsuarioPerfil");
            DropTable("dbo.CE_Usuario");
            DropTable("dbo.CE_Endereco");
            DropTable("dbo.CE_Categoria");
            DropTable("dbo.CE_Empresa");
            DropTable("dbo.CE_PedidoDelivery");
            DropTable("dbo.CE_Pedido");
            DropTable("dbo.CE_PedidoProduto");
            DropTable("dbo.CE_Produto");
            DropTable("dbo.CE_ProdCaractValor");
            DropTable("dbo.CE_CaracteristicaValor");
            DropTable("dbo.CE_Caracteristica");
        }
    }
}

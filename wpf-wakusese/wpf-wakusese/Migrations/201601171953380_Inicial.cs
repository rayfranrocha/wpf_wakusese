namespace wpf_wakusese.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.tb_empresa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cnpj = c.String(),
                        nome = c.String(),
                        percTxServico = c.Decimal(nullable: false, precision: 18, scale: 2),
                        valorTxEntrega = c.Decimal(nullable: false, precision: 18, scale: 2),
                        endereco_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.tb_endereco", t => t.endereco_id)
                .Index(t => t.endereco_id);
            
            CreateTable(
                "public.tb_endereco",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        logradouro = c.String(),
                        pontoReferencia = c.String(),
                        cep = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.tb_funcionalidade",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.tb_perfil",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        empresa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.tb_empresa", t => t.empresa_id, cascadeDelete: true)
                .Index(t => t.empresa_id);
            
            CreateTable(
                "public.tb_usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        senha = c.String(),
                        macTelefone = c.String(),
                        telefone = c.String(),
                        isPermanecerLogado = c.Boolean(nullable: false),
                        ultimaEmpresa_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.tb_empresa", t => t.ultimaEmpresa_id)
                .Index(t => t.ultimaEmpresa_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.tb_usuario", "ultimaEmpresa_id", "public.tb_empresa");
            DropForeignKey("public.tb_perfil", "empresa_id", "public.tb_empresa");
            DropForeignKey("public.tb_empresa", "endereco_id", "public.tb_endereco");
            DropIndex("public.tb_usuario", new[] { "ultimaEmpresa_id" });
            DropIndex("public.tb_perfil", new[] { "empresa_id" });
            DropIndex("public.tb_empresa", new[] { "endereco_id" });
            DropTable("public.tb_usuario");
            DropTable("public.tb_perfil");
            DropTable("public.tb_funcionalidade");
            DropTable("public.tb_endereco");
            DropTable("public.tb_empresa");
        }
    }
}

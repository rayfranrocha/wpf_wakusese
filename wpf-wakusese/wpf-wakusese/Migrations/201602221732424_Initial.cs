namespace wpf_wakusese.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.tb_categoria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        categoriaPai_id = c.Int(),
                        empresa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.tb_categoria", t => t.categoriaPai_id)
                .ForeignKey("public.tb_empresa", t => t.empresa_id, cascadeDelete: true)
                .Index(t => t.categoriaPai_id)
                .Index(t => t.empresa_id);
            
            CreateTable(
                "public.tb_produto",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        descricao = c.String(),
                        preco = c.Decimal(precision: 18, scale: 2),
                        avaliacaoMedia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        img1 = c.Binary(),
                        categoria_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.tb_categoria", t => t.categoria_id)
                .Index(t => t.categoria_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.tb_produto", "categoria_id", "public.tb_categoria");
            DropForeignKey("public.tb_categoria", "empresa_id", "public.tb_empresa");
            DropForeignKey("public.tb_categoria", "categoriaPai_id", "public.tb_categoria");
            DropIndex("public.tb_produto", new[] { "categoria_id" });
            DropIndex("public.tb_categoria", new[] { "empresa_id" });
            DropIndex("public.tb_categoria", new[] { "categoriaPai_id" });
            DropTable("public.tb_produto");
            DropTable("public.tb_categoria");
        }
    }
}

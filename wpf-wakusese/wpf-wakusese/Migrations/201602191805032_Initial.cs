namespace wpf_wakusese.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.tb_perfil", "empresa_id", "public.tb_empresa");
            DropForeignKey("public.tb_usuario", "ultimaEmpresa_id", "public.tb_empresa");
            DropIndex("public.tb_perfil", new[] { "empresa_id" });
            DropIndex("public.tb_usuario", "IX_UsuarioEmail");
            DropIndex("public.tb_usuario", "IX_UsuarioMacTelefone");
            DropIndex("public.tb_usuario", new[] { "ultimaEmpresa_id" });
            DropTable("public.tb_funcionalidade");
            DropTable("public.tb_perfil");
            DropTable("public.tb_usuario");
        }
        
        public override void Down()
        {
            CreateTable(
                "public.tb_usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false),
                        facebook = c.String(),
                        instagram = c.String(),
                        senha = c.String(),
                        nome = c.String(),
                        imeiTelefone = c.String(),
                        telefone = c.String(),
                        dataNascimento = c.DateTime(nullable: false),
                        isPermanecerLogado = c.Boolean(nullable: false),
                        ultimaEmpresa_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.tb_perfil",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        perfilPadraoEnum = c.Int(nullable: false),
                        empresa_id = c.Int(nullable: false),
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
            
            CreateIndex("public.tb_usuario", "ultimaEmpresa_id");
            CreateIndex("public.tb_usuario", "imeiTelefone", unique: true, name: "IX_UsuarioMacTelefone");
            CreateIndex("public.tb_usuario", "email", unique: true, name: "IX_UsuarioEmail");
            CreateIndex("public.tb_perfil", "empresa_id");
            AddForeignKey("public.tb_usuario", "ultimaEmpresa_id", "public.tb_empresa", "id");
            AddForeignKey("public.tb_perfil", "empresa_id", "public.tb_empresa", "id", cascadeDelete: true);
        }
    }
}

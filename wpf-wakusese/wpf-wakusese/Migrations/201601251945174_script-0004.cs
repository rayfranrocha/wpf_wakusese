namespace wpf_wakusese.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class script0004 : DbMigration
    {
        public override void Up()
        {
            DropIndex("public.tb_usuario", "IX_UsuarioMacTelefone");
            AddColumn("public.tb_perfil", "perfilPadraoEnum", c => c.Int(nullable: false));
            AddColumn("public.tb_usuario", "facebook", c => c.String());
            AddColumn("public.tb_usuario", "instagram", c => c.String());
            AddColumn("public.tb_usuario", "nome", c => c.String());
            AddColumn("public.tb_usuario", "imeiTelefone", c => c.String());
            AddColumn("public.tb_usuario", "dataNascimento", c => c.DateTime(nullable: false));
            CreateIndex("public.tb_usuario", "imeiTelefone", unique: true, name: "IX_UsuarioMacTelefone");
            DropColumn("public.tb_usuario", "macTelefone");
        }
        
        public override void Down()
        {
            AddColumn("public.tb_usuario", "macTelefone", c => c.String());
            DropIndex("public.tb_usuario", "IX_UsuarioMacTelefone");
            DropColumn("public.tb_usuario", "dataNascimento");
            DropColumn("public.tb_usuario", "imeiTelefone");
            DropColumn("public.tb_usuario", "nome");
            DropColumn("public.tb_usuario", "instagram");
            DropColumn("public.tb_usuario", "facebook");
            DropColumn("public.tb_perfil", "perfilPadraoEnum");
            CreateIndex("public.tb_usuario", "macTelefone", unique: true, name: "IX_UsuarioMacTelefone");
        }
    }
}

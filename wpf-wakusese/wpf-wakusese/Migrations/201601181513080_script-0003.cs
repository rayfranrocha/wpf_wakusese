namespace wpf_wakusese.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class script0003 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("public.tb_usuario", "macTelefone", unique: true, name: "IX_UsuarioMacTelefone");
        }
        
        public override void Down()
        {
            DropIndex("public.tb_usuario", "IX_UsuarioMacTelefone");
        }
    }
}

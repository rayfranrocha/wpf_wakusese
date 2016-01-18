namespace wpf_wakusese.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class script0002 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("public.tb_usuario", "email", unique: true, name: "IX_UsuarioEmail");
        }
        
        public override void Down()
        {
            DropIndex("public.tb_usuario", "IX_UsuarioEmail");
        }
    }
}

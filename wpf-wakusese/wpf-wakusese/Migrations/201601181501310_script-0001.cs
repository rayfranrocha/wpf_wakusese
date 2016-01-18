namespace wpf_wakusese.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class script0001 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.tb_usuario", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("public.tb_usuario", "email", c => c.String());
        }
    }
}

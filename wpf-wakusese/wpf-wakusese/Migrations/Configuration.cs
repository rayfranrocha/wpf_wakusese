namespace wpf_wakusese.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using wpf_wakusese.model;
    using wpf_wakusese.src.main.model;
    using wpf_wakusese.src.main.model.seguranca;

    internal sealed class Configuration : DbMigrationsConfiguration<wpf_wakusese.src.main._utils.EFDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(wpf_wakusese.src.main._utils.EFDBContext context)
        {
            BoSeguranca bo = new BoSeguranca();
            Funcionalidade f = new Funcionalidade() { nome = "usuario_tela" };
            
            bo.daoFuncionalidade.Inserir(f);
            
            bo.Commit();
        }
    }
}

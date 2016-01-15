using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using wpf_wakusese.model;

namespace wpf_wakusese.src.main._utils
{
    //classe que mapeia os CEs

    public class EFDBContext : DbContext
    {
        public EFDBContext()
            : base("name=wakuseseDB")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            declararDBSets();
        }

        static Dictionary<Type, object> listaDBSetDeclarados = new Dictionary<Type, object>();

        //Seguranca
        public DbSet<Funcionalidade> Funcionalidades { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        //Cadastros
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        private void declararDBSets()
        {
            listaDBSetDeclarados.Add(typeof(Funcionalidade), Funcionalidades);
            listaDBSetDeclarados.Add(typeof(Perfil), Perfis);
            listaDBSetDeclarados.Add(typeof(Empresa), Empresas);
            listaDBSetDeclarados.Add(typeof(Endereco), Enderecos);
        }

        public object GetDBSet(Type tipo)
        {
            object resultado = null;

            if (!listaDBSetDeclarados.TryGetValue(tipo, out resultado))
            {
                throw new ArgumentException("Não existe DbSet para " + tipo.Name);
            }

            return resultado;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var serv = PluralizationService.CreateService(new System.Globalization.CultureInfo("en-us"));

            modelBuilder.Types()
             .Configure(entity => entity.ToTable("tb_" + serv.Singularize(entity.ClrType.Name).ToString().ToLower(), "public"));

            base.OnModelCreating(modelBuilder);

        }

    }
}

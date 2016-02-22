using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main._utils
{
    //classe que mapeia os CEs

    public class EFDBContext : DbContext
    {

        #region Instance - padrao Singleton
        private static EFDBContext _instance;

        public static EFDBContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EFDBContext();
                }

                return _instance;

            }
            set { _instance = value; }
        }
        #endregion

        public EFDBContext()
            : base("name=wakuseseDB")
        {
            //imprime o LOG na aba Output
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        //Seguranca
        public DbSet<Funcionalidade> Funcionalidades { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfil { get; set; }
        public DbSet<PerfilFuncionalidade> PerfilFuncionalidades { get; set; }

        //Cadastros
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public object GetDBSet(Type tipo)
        {
            object r = null;

            switch (tipo.Name.ToString())
            {
                case "Empresa": return Empresas;
                case "Endereco": return Enderecos;
                case "Funcionalidade": return Funcionalidades;
                case "Perfil": return Perfis;
                case "Usuario": return Usuarios;
                case "UsuarioPerfil": return UsuarioPerfil;
                case "PerfilFuncionalidade": return PerfilFuncionalidades;
                case "Categoria": return Categorias;
                case "Produto": return Produtos;
            }
            return r;

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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.ce;
using System.Data.Entity;

namespace wpf_wakusese.src.main.model.bo
{
    public class BO_Perfil : GenericoBO<Perfil>
    {
        public BO_Perfil()
            : base()
        {
        }

        public override ObservableCollection<Perfil> ObterListaObjeto()
        {

            List<Perfil> lista = _DbSet
                                       .Include(o => o.empresa)
                                       .Include(o => o.empresa.endereco)
                                       .OrderBy(o => o.id)
                                       .ToList();

            ObservableCollection<Perfil> listObv = new ObservableCollection<Perfil>(lista);

            return listObv;
        }

        public ObservableCollection<Perfil> ObterListaEmpresaPerfil(Empresa emp)
        {
            if (emp != null)
            {
                List<Perfil> lista = _DbSet
                                           .OrderBy(o => o.id)
                                           .Where(o => emp.id == o.empresa.id)
                                           .ToList();

                ObservableCollection<Perfil> listObv = new ObservableCollection<Perfil>(lista);

                return listObv;
            }
            else
            {
                return null;
            }


        }

        public Perfil ObterObjetoPerfilPorPerfilId(int idPerfil)
        {
            Perfil perfil =
                           _DbSet
                                 .Include(o => o.empresa)
                                 .Where(o => o.id == idPerfil)
                                 .FirstOrDefault();
            return perfil;
        }

        public Perfil ObterObjetoPerfilPorNomeEEmpresaID(int idEmpresa, string nomePerfil)
        {
            Perfil perfil =
                           _DbSet
                //.Include(o => o.empresa)
                                 .Where(o => o.empresa.id == idEmpresa && o.nome == nomePerfil)
                                 .FirstOrDefault();
            return perfil;
        }
    }
}

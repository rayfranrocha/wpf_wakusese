using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.ce;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace wpf_wakusese.src.main.model.bo
{
    public class BO_PerfilFuncionalidade : GenericoBO<PerfilFuncionalidade>
    {
        public List<PerfilFuncionalidade> ObterListaObjeto(UsuarioPerfil up)
        {

            List<PerfilFuncionalidade> r = _DbSet
                //
                                                   .Include(o => o.funcionalidade)  // .Include(o=> o.funcionalidade)
                                                   .Where(o => o.perfil.id == up.perfil.id) //  .Where(o => o.perfil == up.perfil)
                                                   .ToList();
            return r;
        }

        public List<PerfilFuncionalidade> ObterListaObjeto(List<Perfil> listaPerfil)
        {
            List<int> listaIds = (from x in listaPerfil
                                  select x.id).ToList();

            List<PerfilFuncionalidade> r = _DbSet
                                                  .Include(o => o.funcionalidade) // *** foi incluido
                                                  .Where(o => listaIds.Contains(o.perfil.id))
                                                  .ToList();
            return r;
        }

        public ObservableCollection<PerfilFuncionalidade> ObterListaFuncinalidadedoPerfilSelecionado(Perfil per)
        {
            if (per != null)
            {
                List<PerfilFuncionalidade> lista = _DbSet
                                           .Include(o => o.funcionalidade)
                                           .OrderBy(o => o.id)
                                           .Where(o => per.id == o.perfil.id)
                                           .ToList();

                ObservableCollection<PerfilFuncionalidade> listObv = new ObservableCollection<PerfilFuncionalidade>(lista);

                return listObv;
            }
            else
            {
                return null;
            }


        }
    }
}

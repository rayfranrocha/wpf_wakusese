using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.model.bo
{
    public class BO_Categoria : GenericoBO<Categoria>
    {

        // comentario teste igo
        //Comentario foi feito pelo ALisson
        public List<Categoria> ObterListaCategoriadaEmpresa(Empresa empresa)
        {
            List<Categoria> lista = null;
            try
            {
                lista = _DbSet
                                      
                                      .Where(o => o.empresa.id == empresa.id)
                                      .OrderBy(o => o.id)
                                      .ToList();
                return lista;
                
            }
            catch (Exception e)
            {
                
                //MessageBox.Show(e.Message);
               // MessageBox.Show("Não há Categoria registradas no banco de dados!");
                return lista;
            }

            
           
        }
    }
}

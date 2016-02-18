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
    public class BO_Produto : GenericoBO<Produto>
    {
        public BO_Produto()
            : base()
        {
        }

        public override ObservableCollection<Produto> ObterListaObjeto()
        {
            List<Produto> lista = _DbSet
                                        .Include(o => o.categoria)
                                        .OrderBy(o => o.id).ToList();
            ObservableCollection<Produto> listObv = new ObservableCollection<Produto>(lista);

            return listObv;
        }

        public ObservableCollection<Produto> ObterListaProdutosPorCategoriaID(Categoria catFocada)
        {
            List<Produto> lista = _DbSet
                                        .Include(o => o.categoria)
                                        .Where(o => o.categoria.id == catFocada.id)
                                        .OrderBy(o => o.id).ToList();
            ObservableCollection<Produto> listObv = new ObservableCollection<Produto>(lista);

            return listObv;
        }

        public Produto ObterProdutoPorId(int id)
        {
            Produto produto = _DbSet
                                   .Include(o => o.categoria)
                                   .Where(o => o.id == id)
                                   .FirstOrDefault();
            return produto;

        }

        public ObservableCollection<Produto> ObterListaDeProdutosPorNome(string p)
        {
            List<Produto> lista = _DbSet

                               .Include(o => o.categoria)
                               .Where(o => o.nome.ToUpper().Contains(p.ToUpper()))
                               .ToList();

            ObservableCollection<Produto> listObv = new ObservableCollection<Produto>(lista);
            return listObv;
        }

        public ObservableCollection<Produto> ObterListaProdutosPorCodigo(string NomeProdutoOrCodigo)
        {
            int codigo = Convert.ToInt32(NomeProdutoOrCodigo);
            List<Produto> lista = _DbSet

                              .Include(o => o.categoria)
                              .Where(o => o.id == codigo)
                              .ToList();

            ObservableCollection<Produto> listObv = new ObservableCollection<Produto>(lista);
            return listObv;
        }

        public ObservableCollection<Produto> ObterListaProdutosdaEmpresa(Empresa empresa)
        {

            List<Produto> lista = _DbSet

                              .Include(o => o.categoria)
                              .Where(o => o.categoria.empresa.id == empresa.id)
                              .ToList();

            ObservableCollection<Produto> listObv = new ObservableCollection<Produto>(lista);
            return listObv;
        }
    }
}

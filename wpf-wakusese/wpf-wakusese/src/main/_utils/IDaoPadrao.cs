using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_wakusese.src.main._utils
{
    public interface IDAOPadrao<T>
    {

        //void AttachTo(T obj);

        void Inserir(T obj);

        //void Alterar(T obj);

        //void Excluir(T obj);

        //void ExcluirPorId(int id);

        //T ObterObjetoPorId(int id);

        //T ObterObjetoAtualizado(T obj);

        //IObservable<T> ObterListaObjeto();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main._utils
{
    public class FactoryBO<T> where T : EntityBase
    {

        public static GenericoBO<T> GetBO()
        {
            object bo = null;
            Type tipoBO;

            if (!CacheBOs.TryGetValue(typeof(T), out bo))
            {

                tipoBO = SearchBOType(typeof(T));

                if (tipoBO != null)
                {
                    bo = Activator.CreateInstance(tipoBO);
                    CacheBOs.Add(typeof(T), bo);
                }
                else
                {
                    throw new Exception("Não existe BO para o tipo " + typeof(T).Name);
                }
            }

            return (GenericoBO<T>)bo;

        }

        static Dictionary<Type, object> CacheBOs = new Dictionary<Type, object>();

        private static Type SearchBOType(Type tipo)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                foreach (var type in assembly.GetTypes())
                    if (type.IsSubclassOf(typeof(GenericoBO<T>)))
                        return type;

            return null;
        }
    }
}
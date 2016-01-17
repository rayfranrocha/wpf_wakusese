using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main.model.cadastros.bo;
using wpf_wakusese.src.main.model.cadastros.ce;
using wpf_wakusese.src.main.model.seguranca.ce;

namespace wpf_wakusese.src.main._utils
{
    class FactoryBO
    {

        public static object GetBO(Type tipoCE)
        {
            object bo = null;
            Type tipoBO;

            if (!Cache.TryGetValue(tipoCE, out bo))
            {
                if (BosConhecidos.TryGetValue(tipoCE, out tipoBO))
                {
                    bo = Activator.CreateInstance(tipoBO);
                    Cache.Add(tipoCE, bo);
                }
                else
                {
                    throw new Exception("Não existe BO para o tipo " + tipoCE.Name);
                }
            }

            return bo;

        }

        static Dictionary<Type, object> Cache = new Dictionary<Type, object>();

        private static Dictionary<Type, Type> BosConhecidos = new Dictionary<Type, Type>()
        {
            { typeof(Empresa), typeof(BOEmpresa) }, 
            { typeof(Funcionalidade), typeof(BoPadrao<Funcionalidade>) }
        };



        //public static BoPadrao<T> GetInstance()
        //{
        //    object bo = null;

        //    if (!Cache.TryGetValue(typeof(T), out bo))
        //    {
        //        Type boType = null;

        //        if (!BosConhecidos.TryGetValue(typeof(T), out boType))
        //        {
        //            var daoType = SearchDAOType();
        //            if (daoType == null)
        //                throw new Exception("Não há DAO para este tipo.");
        //            else
        //                bo = new BoPadrao<T>((DaoPadrao<T>)Activator.CreateInstance(daoType));
        //        }
        //        else
        //            bo = Activator.CreateInstance(boType);

        //        Cache.Add(typeof(T), bo);
        //    }

        //    return (BoPadrao<T>)bo;
        //}

        //private static Type SearchDAOType()
        //{
        //    foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        //        foreach (var type in assembly.GetTypes())
        //            if (type.IsSubclassOf(typeof(DaoPadrao<T>)))
        //                return type;

        //    return null;
        //}

        //static Dictionary<Type, Type> BosConhecidos = new Dictionary<Type, Type>()
        //{
        //    { typeof(Empresa), typeof(BOEmpresa) }
        //};

        //static Dictionary<Type, object> Cache = new Dictionary<Type, object>();

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_wakusese.src.main._utils
{
    public class IconUtil
    {
        public ObservableCollection<T> ConverterL2OC<T>(IList<T> obj)
        {
            return new ObservableCollection<T>(obj);            
        }
 
    }
}

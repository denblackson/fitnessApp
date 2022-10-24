using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness.BLL.Controller
{
    public interface IDataSaver
    {
         void Save(string fileName, object item);
         T Load<T>(string fileName);
    }
}

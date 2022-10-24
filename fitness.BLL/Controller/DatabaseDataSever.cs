using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness.BLL.Controller
{
    public class DatabaseDataSever : IDataSaver
    {
        public T Load<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public void Save(string fileName, object item)
        {
            throw new NotImplementedException();
        }
    }
}

using fitness.BLL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace fitness.BLL.Controller
{
    public abstract class ControllerBase
    {
        /// <summary>
        /// Save Users data
        /// </summary>
        /// 

        protected IDataSaver _dataSaver = new  SerializeDataSever();


        protected void Save(string fileName, object item)
        {
           _dataSaver.Save(fileName, item);
        }


        protected T Load<T>(string fileName)
        {
            return _dataSaver.Load<T>(fileName);
        }
    }
}

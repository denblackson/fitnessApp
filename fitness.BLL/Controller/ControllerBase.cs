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
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var filestream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(filestream, item);

            }
        }


        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var filestream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (filestream.Length > 0 && formatter.Deserialize(filestream) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }

            }
        }
    }
}

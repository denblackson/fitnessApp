using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace fitness.BLL.Controller
{
    class SerializeDataSever : IDataSaver
    {
        public T Load<T>(string fileName)
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

        public void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var filestream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(filestream, item);

            }
        }
    }
}

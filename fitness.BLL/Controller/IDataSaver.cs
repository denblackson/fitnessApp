using System.Collections.Generic;

namespace fitness.BLL.Controller
{
    public interface IDataSaver
    {
        void Save<T>(List<T> item) where T : class; // type to save to 
        List<T> Load<T>() where T : class;   // get collection 
    }

}
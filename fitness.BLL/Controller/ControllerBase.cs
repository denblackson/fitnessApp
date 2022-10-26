using fitness.BLL.Controller;
using System.Collections.Generic;



namespace fitness.BLL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDataSaver manager = new DatabaseSaver(); // можем підмтавити як  DatabaseSaver так і сереалізацію в файл,
                                                                   // тобто любий клас, що реалізує інтерфейс

        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }


        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}
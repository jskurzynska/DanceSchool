using System.Collections.Generic;

namespace TestingClasses.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Remove(T item);
        T GetFirstItem();
        IEnumerable<T> GetAll();
    }
}

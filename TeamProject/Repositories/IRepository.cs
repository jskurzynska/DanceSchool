using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Remove(T item);
        T GetFirstItem();
        IEnumerable<T> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using TeamProject.Services;

namespace TeamProject.Repositories
{
    public class Repository<T> : IRepository<T> where T: class
    {
        protected readonly SQLiteConnection Context;

        public Repository(SQLiteConnection context)
        {
            Context = context;
        }

        public void Add(T item)
        {
            Context.Table<T>().Connection.InsertOrReplace(item);
        }

        public void Remove(T item)
        {
            Context.Table<T>().Connection.Delete(item); 
        }

        public T GetFirstItem()
        {
            return Context.Table<T>().FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return GetFirstItem() == null ? null : Context.Table<T>().ToList();
        }
    }
}

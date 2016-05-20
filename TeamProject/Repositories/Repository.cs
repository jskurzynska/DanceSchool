using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;

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

        public void RemoveAll()
        {
            Context.Table<T>().Connection.DeleteAll<T>();
        }
    }
}

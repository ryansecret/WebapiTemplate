using System;
using System.Collections.Generic;

namespace Ryan.Repository
{
    public interface IRepository<T,K> where T:class,new() where K:struct 
    {
        T FindBy(K key);

        IList<T> FindAll();

        void Add(T item);

        void Update(T item);

        void Remove(T item);

        void RemoveAll();
    }
}
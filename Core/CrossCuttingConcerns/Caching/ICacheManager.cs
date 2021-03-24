using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value,int duration);//herseyin atasi object oldugundan 
        bool IsAdd(string key);//Cachede var mi varsa cacheden don yoksa cache ekle 
        void Remove(string key);
        void RemoveByPattern(string pattern);// istenilen turdekileri kaldir.

    }
}

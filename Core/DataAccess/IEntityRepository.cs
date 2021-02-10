using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAcces
{
    //generic constraint -- class : referans tip //generic constraint -- class : referans tip
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir 
    //new eklenirse IEntity interfacesinden kurtuluruz.
    //sistem artik sadece veri tabani nesneleriyle calisan bir repository ,dk70
    public interface IEntityRepository<T> where T:class,IEntity,new() // generic tasarim deseni 

    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//urunleri filtrelemeyi saglayan linq Expressions
        T Get(Expression<Func<T, bool>> filter); //urunun spesifik ozelligi isterek filtrelemeyi ister.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       

    }
}

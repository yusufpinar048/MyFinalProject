using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //where T : generic constraint(kısıtlama)
    //class: referans tip olabilir 
    //IEntity:IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() : new ' lenebilir olmalı
    public interface IEntityRepository<T> where T : class,IEntity, new()
    {
        /// <summary>
        /// jenerik kolonlarda filtreleme yapma (Expression)
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        List<T> GetAllByCategory(int categoryId);
    }
}

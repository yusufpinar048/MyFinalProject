using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : Abstract.EfProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern iplementaion of c# (işlemi yaptıktan sonra belleği temizliyor using)
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //referansı yakalıyoruz Entry ile
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //referansı yakalıyoruz Entry ile
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? 
                    context.Set<Product>().ToList() : 
                    context.Set<Product>().Where(filter).ToList();

            }
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //referansı yakalıyoruz Entry ile
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

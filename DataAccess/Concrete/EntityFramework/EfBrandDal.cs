using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using RentACarDbContext dbContext = new RentACarDbContext();
            var addedEntity = dbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            dbContext.SaveChanges();
        }

        public void Delete(Brand entity)
        {
            using RentACarDbContext dbContext = new RentACarDbContext();
            var deletedEntity = dbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using RentACarDbContext dbContext = new RentACarDbContext();
            return dbContext.Set<Brand>().SingleOrDefault(filter);
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using RentACarDbContext dbContext = new RentACarDbContext();
            return filter == null ?
                dbContext.Set<Brand>().ToList() :
                dbContext.Set<Brand>().Where(filter).ToList();
        }

        public void Update(Brand entity)
        {
            using RentACarDbContext dbContext = new RentACarDbContext();
            var updatedEntity = dbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}

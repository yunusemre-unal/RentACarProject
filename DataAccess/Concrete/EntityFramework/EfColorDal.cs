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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using RentACarDbContext dbContext = new RentACarDbContext();
            var addedEntity = dbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            dbContext.SaveChanges();
        }

        public void Delete(Color entity)
        {
            using RentACarDbContext dbContext = new RentACarDbContext();
            var deletedEntity = dbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using RentACarDbContext dbContext = new RentACarDbContext();
            return dbContext.Set<Color>().SingleOrDefault(filter);
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using RentACarDbContext dbContext = new RentACarDbContext();
            return filter == null ?
                dbContext.Set<Color>().ToList() :
                dbContext.Set<Color>().Where(filter).ToList();
        }

        public void Update(Color entity)
        {
            using RentACarDbContext dbContext = new RentACarDbContext();
            var updatedEntity = dbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}

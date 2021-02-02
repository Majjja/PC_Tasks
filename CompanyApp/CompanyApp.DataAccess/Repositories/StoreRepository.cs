using CompanyApp.DataAccess.Context;
using CompanyApp.DataAccess.Interfaces;
using CompanyApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CompanyApp.DataAccess.Repositories
{
    public class StoreRepository : RepositoryBase, IRepository<Store>
    {
        public StoreRepository(CompanyDbContext context) : base(context) { }

        public IEnumerable<Store> GetAll()
        {
            return _db.Stores;
        }

        public Store GetById(int id)
        {
            var store = GetAll().SingleOrDefault(s => s.Id == id);
            if (store != null)
            {
                return store;
            }
            return null;
        }

        public void Insert(Store store)
        {
            var existed = GetById(store.Id);
            if (existed == null)
            {
                _db.Stores.Add(store);
                _db.SaveChanges();
            }
        }

        public void Update(Store store)
        {
            var existed = GetById(store.Id);
            if (existed != null)
            {
                _db.Stores.Update(store);
                _db.SaveChanges();
            }
        }

        public void Delete(Store store)
        {
            var existed = GetById(store.Id);
            if (existed != null)
            {
                _db.Stores.Remove(store);
                _db.SaveChanges();
            }
        }
    }
}

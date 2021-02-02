using CompanyApp.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApp.DataAccess.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly CompanyDbContext _db;
        public RepositoryBase(CompanyDbContext db)
        {
            _db = db;
        }
    }
}

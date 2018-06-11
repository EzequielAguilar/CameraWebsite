using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assignment1.Models
{
    public class EFCompaniesRepository : IMockCompaniesRepository
    {
        //// db conn moved here from artists controller
        //private ApplicationDbContext db = new ApplicationDbContext();

        //public IQueryable<company> Companies { get { return db.companies; } }

        //public IQueryable<company> companies => throw new NotImplementedException();

        //public void Delete(company company)
        //{
        //    throw new NotImplementedException();
        //}

        //public company Save(company company)
        //{
        //    throw new NotImplementedException();
        //}
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<company> companies { get { return db.companies; } }

        public void Delete(company company)
        {
            throw new NotImplementedException();
        }

        public company Save(company company)
        {
            throw new NotImplementedException();
        }
    }
}
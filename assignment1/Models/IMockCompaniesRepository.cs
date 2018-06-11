using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1.Models
{
    public interface IMockCompaniesRepository
    {
        IQueryable<company> companies { get; }
        company Save(company company);
        void Delete(company company);
    }
}

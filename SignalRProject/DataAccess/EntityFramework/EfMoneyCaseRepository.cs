using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfMoneyCaseRepository : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseRepository(SignalRContext context) : base(context)
        {
        }

        public double TotalMoneyCaseAmount()
        {
            using var context=new SignalRContext();
            return context.MoneyCases.Select(x=>x.TotalAmount).FirstOrDefault();
        }
    }
}

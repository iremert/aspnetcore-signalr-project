using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfBasketRepository : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketRepository(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketWithCarWithTable(int id)
        {
            var context = new SignalRContext();
            return context.Baskets.Include(x => x.Car).Where(y => y.TableNumberId == id).ToList(); 
        }
    }
}

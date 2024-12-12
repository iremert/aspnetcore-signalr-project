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
    public class EfOrderRepository : GenericRepository<Order>, IOrderDal
    {
        public EfOrderRepository(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x=>x.State== "Müşteri Masada").Count();
        }

        public double LastOrderPrice()
        {
            using var context= new SignalRContext();
            return context.Orders.OrderByDescending(x=>x.OrderId).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
        }

        public double TodayTotalPrice()
        {
            using var context=new SignalRContext();
            return context.Orders.Where(x => x.Date == DateTime.Parse(DateTime.Now.ToShortDateString())).Sum(y => y.TotalPrice);
        }

        public int TotalOrderCount()
        {
            using var context=new SignalRContext();
            return context.Orders.Count();
        }
    }
}

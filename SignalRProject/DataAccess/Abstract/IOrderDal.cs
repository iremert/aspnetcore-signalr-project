using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal:IGenericDal<Order>
    {
        public int ActiveOrderCount();
        public int TotalOrderCount();
        public double LastOrderPrice();
        public double TodayTotalPrice();
    }
}

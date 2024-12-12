using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IOrderService:IGenericService<Order>
    {
        public int TActiveOrderCount();
        public int TTotalOrderCount();
        public double TLastOrderPrice();
        public double TTodayTotalPrice();
    }
}

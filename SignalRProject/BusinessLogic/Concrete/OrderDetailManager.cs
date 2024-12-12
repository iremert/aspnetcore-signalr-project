using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public void TDelete(OrderDetail t)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> TGetAll()
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> TGetAllWithFilter(Expression<Func<OrderDetail, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public OrderDetail TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(OrderDetail t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(OrderDetail t)
        {
            throw new NotImplementedException();
        }
    }
}

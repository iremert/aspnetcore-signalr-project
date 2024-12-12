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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void TDelete(Basket t)
        {
            _basketDal.Delete(t);
        }

        public List<Basket> TGetAll()
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetAllWithFilter(Expression<Func<Basket, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Basket TGetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public void TInsert(Basket t)
        {
            _basketDal.Insert(t);   
        }

        public void TUpdate(Basket t)
        {
            throw new NotImplementedException();
        }
    }
}

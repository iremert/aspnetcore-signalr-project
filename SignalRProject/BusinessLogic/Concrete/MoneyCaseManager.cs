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
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }

        public void TDelete(MoneyCase t)
        {
            throw new NotImplementedException();
        }

        public List<MoneyCase> TGetAll()
        {
            throw new NotImplementedException();
        }

        public List<MoneyCase> TGetAllWithFilter(Expression<Func<MoneyCase, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public MoneyCase TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(MoneyCase t)
        {
            throw new NotImplementedException();
        }

        public double TotalMoneyCaseAmount()
        {
            return _moneyCaseDal.TotalMoneyCaseAmount();
        }

        public void TUpdate(MoneyCase t)
        {
            throw new NotImplementedException();
        }
    }
}

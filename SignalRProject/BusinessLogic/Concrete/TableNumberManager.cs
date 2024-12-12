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
    public class TableNumberManager : ITableNumberService
    {
        private readonly ITableNumberDal _tableNumberDal;

        public TableNumberManager(ITableNumberDal tableNumberDal)
        {
            _tableNumberDal = tableNumberDal;
        }

        public int TActiveTableNumber()
        {
            return _tableNumberDal.ActiveTableNumber();
        }

        public void TChangeStatusToFalse(int id)
        {
            _tableNumberDal.ChangeStatusToFalse(id);
        }

        public void TChangeStatusToTrue(int id)
        {
            _tableNumberDal.ChangeStatusToTrue(id);
        }

        public void TDelete(TableNumber t)
        {
             _tableNumberDal.Delete(t);
        }

        public List<TableNumber> TGetAll()
        {
            return _tableNumberDal.GetAll();
        }

        public List<TableNumber> TGetAllWithFilter(Expression<Func<TableNumber, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public TableNumber TGetById(int id)
        {
            return _tableNumberDal.GetById(id);
        }

        public void TInsert(TableNumber t)
        {
            _tableNumberDal.Insert(t);
        }

        public void TUpdate(TableNumber t)
        {
            _tableNumberDal.Update(t);
        }
    }
}

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
	public class BrandManager:IBrandService
	{
		private readonly IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

        public int TActiveBrandCount()
        {
            return _brandDal.ActiveBrandCount();
        }

        public List<Brand> TActiveBrandList()
        {
			return _brandDal.GetActiveBrand();
        }

        public int TBrandCount()
        {
            return _brandDal.BrandCount();
        }

        public void TChangeStatusToFalse(int id)
        {
			_brandDal.ChangeStatusToFalse(id);
        }

        public void TChangeStatusToTrue(int id)
        {
			_brandDal.ChangeStatusToTrue(id);
        }

        public void TDelete(Brand t)
		{
			_brandDal.Delete(t);
		}

		public List<Brand> TGetAll()
		{
			var liste=_brandDal.GetAll();
			return liste;
		}

		public List<Brand> TGetAllWithFilter(Expression<Func<Brand, bool>> filter)
		{
			var liste=_brandDal.GetAllWithFilter(filter);
			return liste;
		}

		public Brand TGetById(int id)
		{
			var deger=_brandDal.GetById(id);
			return deger;
		}

		public void TInsert(Brand t)
		{
			_brandDal.Insert(t);
		}

        public int TPassiveBrandCount()
        {
            return _brandDal.PassiveBrandCount();
        }

        public void TUpdate(Brand t)
		{
			_brandDal.Update(t);
		}
	}
}
